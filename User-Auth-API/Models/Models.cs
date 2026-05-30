using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace User_Auth_Api.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.HasMany(e => e.RefreshTokens)
                  .WithOne()
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<RefreshToken>(entity =>
        {
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.Token);
        });

        base.OnModelCreating(builder);
    }
}

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}

public class RefreshToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public bool Used { get; set; }
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}

public class RegisterUser
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginUser
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class JwtResponse
{
    public string Token { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

public class AuthResponse
{
    public string Message { get; set; } = string.Empty;
    public JwtResponse? Jwt { get; set; }
}

public class TokenResponse
{
    public string Token { get; set; } = string.Empty;
}
