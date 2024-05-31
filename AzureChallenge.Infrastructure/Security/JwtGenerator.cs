using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AzureChallenge.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AzureChallenge.Infrastructure.Security;

public class JwtGenerator(IOptions<JwtSettings> jwtOptions) : IJwtGenerator
{
  private readonly JwtSettings _jwtSettings= jwtOptions.Value;

    public string GenerateToken(int userId, string email, string firstName, string lastName)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new Claim[]
      {
        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        new Claim(ClaimTypes.Email, email),
        new Claim(ClaimTypes.Name, firstName),
        new Claim(ClaimTypes.GivenName, lastName),
      }),
      //TODO: Add refresh token -> decrease the lifetime.
      Expires = _jwtSettings.ExpiryMinutes > 0 ? DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes) : DateTime.UtcNow.AddHours(1),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
      Issuer = _jwtSettings.Issuer,
      Audience = _jwtSettings.Audience
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
