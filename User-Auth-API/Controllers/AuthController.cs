using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace User_Auth_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly TokenService _tokenService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        TokenService tokenService,
        ILogger<AuthController> logger)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    // POST: api/auth/register
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> Register(RegisterUser registerUser)
    {
        if (await _userManager.Users.AnyAsync(u => u.UserName == registerUser.Username))
        {
            return BadRequest("Username already taken.");
        }

        if (await _userManager.Users.AnyAsync(u => u.Email == registerUser.Email))
        {
            return BadRequest("Email already taken.");
        }

        var user = new ApplicationUser
        {
            UserName = registerUser.Username,
            Email = registerUser.Email,
            FirstName = registerUser.FirstName,
            LastName = registerUser.LastName,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(user, registerUser.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var token = await _tokenService.GenerateToken(user);

        return Ok(new AuthResponse
        {
            Message = "User created successfully",
            Jwt = new JwtResponse
            {
                Token = token.Token,
                Type = token.Type
            }
        });
    }

    // POST: api/auth/login
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> Login(LoginUser loginUser)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == loginUser.Username || u.Email == loginUser.Username);

        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        var passwordValidator = new PasswordValidator<ApplicationUser>();
        var result = await passwordValidator.ValidateAsync(_userManager, user, loginUser.Password);

        if (!result.Succeeded)
        {
            return Unauthorized(new { errors = result.Errors });
        }

        var token = await _tokenService.GenerateToken(user);

        return Ok(new AuthResponse
        {
            Message = "Login successful",
            Jwt = new JwtResponse
            {
                Token = token.Token,
                Type = token.Type
            }
        });
    }

    // POST: api/auth/refresh
    [HttpPost("refresh")]
    public async Task<ActionResult<TokenResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == request.Username);

        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        var newToken = await _tokenService.GenerateToken(user);

        return Ok(new TokenResponse { Token = newToken.Token });
    }

    // GET: api/auth/me
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<ApplicationUser>> GetCurrentUser()
    {
        var user = _userManager.GetUserById(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        return Ok(await user);
    }

    // POST: api/auth/logout
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user != null)
        {
            _tokenService.RevokeAllTokens(user.Id);
        }

        return Ok(new { message = "Logged out successfully" });
    }
}

public class RefreshTokenRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class TokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IJwtSettings _jwtSettings;

    public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
        _jwtSettings = new JwtSettings
        {
            Issuer = _configuration["Jwt:Issuer"] ?? "MohammadThiab",
            Audience = _configuration["Jwt:Audience"] ?? "MohammadThiab",
            Key = _configuration["Jwt:Key"] ?? "ThisIsAKeyThatIsLongEnoughForJwTAu0thentication",
            AccessTokenExpiration = _configuration["Jwt:AccessTokenExpiration"] ?? "1h",
            RefreshTokenExpiration = _configuration["Jwt:RefreshTokenExpiration"] ?? "7d"
        };
    }

    public async Task<TokenResponse> GenerateToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
            new Claim(ClaimTypes.Surname, user.LastName ?? "")
        };

        var tokenKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                tokenKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        var refreshToken = new RefreshToken
        {
            Token = _crypto.GenerateToken(),
            Created = DateTime.UtcNow,
            Expiration = DateTime.UtcNow.AddMilliseconds(7 * 24 * 60 * 60 * 1000)
        };

        await _userManager.AddRefreshTokenAsync(user, refreshToken);

        return new TokenResponse
        {
            Token = accessToken,
            Type = "Bearer"
        };
    }

    public void RevokeAllTokens(string userId)
    {
        var tokens = _userManager.RefreshTokens
            .Where(t => t.UserId == userId);

        foreach (var token in tokens)
        {
            token.Used = true;
            token.Revoked = DateTime.UtcNow;
        }

        _userManager.UpdateRefreshTokensAsync(tokens.ToList());
    }
}

public class JwtSettings
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string AccessTokenExpiration { get; set; } = "1h";
    public string RefreshTokenExpiration { get; set; } = "7d";
}

public class TokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IJwtSettings _jwtSettings;

    public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
        _jwtSettings = new JwtSettings
        {
            Issuer = _configuration["Jwt:Issuer"] ?? "MohammadThiab",
            Audience = _configuration["Jwt:Audience"] ?? "MohammadThiab",
            Key = _configuration["Jwt:Key"] ?? "ThisIsAKeyThatIsLongEnoughForJwTAu0thentication",
            AccessTokenExpiration = _configuration["Jwt:AccessTokenExpiration"] ?? "1h",
            RefreshTokenExpiration = _configuration["Jwt:RefreshTokenExpiration"] ?? "7d"
        };
    }

    public async Task<TokenResponse> GenerateToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
            new Claim(ClaimTypes.Surname, user.LastName ?? "")
        };

        var tokenKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                tokenKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        var refreshToken = new RefreshToken
        {
            Token = _crypto.GenerateToken(),
            Created = DateTime.UtcNow,
            Expiration = DateTime.UtcNow.AddMilliseconds(7 * 24 * 60 * 60 * 1000)
        };

        await _userManager.AddRefreshTokenAsync(user, refreshToken);

        return new TokenResponse
        {
            Token = accessToken,
            Type = "Bearer"
        };
    }

    public void RevokeAllTokens(string userId)
    {
        var tokens = _userManager.RefreshTokens
            .Where(t => t.UserId == userId);

        foreach (var token in tokens)
        {
            token.Used = true;
            token.Revoked = DateTime.UtcNow;
        }

        _userManager.UpdateRefreshTokensAsync(tokens.ToList());
    }
}
