using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AzureChallenge.Application.Interfaces;
using AzureChallenge.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AzureChallenge.Infrastructure.Security;

public class JwtGenerator(IOptions<JwtSettings> jwtOptions) : IJwtGenerator
{
  private readonly JwtSettings _jwtSettings= jwtOptions.Value;

    public string GenerateToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new Claim[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.FirstName),
        new Claim(ClaimTypes.GivenName, user.LastName),
        new Claim(ClaimTypes.Role, user.Roles.Any() ? user.Roles.Select(x => x.Name.ToLower()).Aggregate((x, y) => $"{x},{y}") ?? "" : ""),
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
