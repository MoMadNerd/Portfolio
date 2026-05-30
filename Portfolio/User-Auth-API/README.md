# User Authentication API

A **secure authentication API** built with **ASP.NET Core Identity** and **JWT**. Perfect for protecting your applications.

## Features

- 🔐 **JWT Authentication** - Secure token-based auth
- 👤 **User Registration** - Email & username validation
- 🔑 **Token Refresh** - Automatic token refresh
- 🚫 **Password Validation** - Strong password requirements
- 📝 **CORS Support** - Frontend integration ready
- 🛡️ **Secure Logout** - Token revocation on logout

## Tech Stack

- **Backend:** ASP.NET Core 8.0, C#
- **Identity:** ASP.NET Core Identity
- **Auth:** JWT (JSON Web Tokens)
- **Database:** SQL Server
- **Documentation:** Swagger/OpenAPI

## Features Demonstrated

- ✅ **User Registration** - Create new user accounts
- ✅ **User Login** - Secure authentication
- ✅ **JWT Tokens** - Stateless token-based auth
- ✅ **Token Refresh** - Automatic refresh mechanism
- ✅ **Secure Logout** - Revoke all tokens
- ✅ **CORS Support** - Web frontend integration

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register new user |
| POST | `/api/auth/login` | Login user |
| POST | `/api/auth/refresh` | Refresh token |
| GET | `/api/auth/me` | Get current user |
| POST | `/api/auth/logout` | Logout user |

## User Registration

```json
{
  "username": "john.doe",
  "email": "john@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "password": "SecurePassword123!"
}
```

## User Login

```json
{
  "username": "john.doe",
  "password": "SecurePassword123!"
}
```

## Response

```json
{
  "message": "Login successful",
  "jwt": {
    "token": "eyJhbGciOiJIUzI1NiIs...",
    "type": "Bearer"
  }
}
```

## How to Run

1. Install dependencies:
   ```bash
   dotnet restore
   ```

2. Migrate database:
   ```bash
   dotnet ef database update
   ```

3. Build and run:
   ```bash
   dotnet build
   dotnet run
   ```

4. Open Swagger UI at: `https://localhost:7002/swagger`

## Example Requests

```bash
# Register user
curl -X POST https://localhost:7002/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john",
    "email": "john@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "password": "SecurePassword123!"
  }'

# Login
curl -X POST https://localhost:7002/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john",
    "password": "SecurePassword123!"
  }'

# Refresh token
curl -X POST https://localhost:7002/api/auth/refresh \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john",
    "password": "SecurePassword123!"
  }'

# Logout
curl -X POST https://localhost:7002/api/auth/logout \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

## Security Features

- **Password Hashing** - Secure password storage
- **JWT Validation** - Token expiration and verification
- **Refresh Tokens** - Secure token rotation
- **CORS Configuration** - Frontend protection
- **Input Validation** - Prevent injection attacks

---

**Built by:** Mohammad Thiab  
**Location:** Ramallah, West Bank, Palestine  
**Available for:** Freelance projects, remote work

Let's build something amazing together! 🚀
