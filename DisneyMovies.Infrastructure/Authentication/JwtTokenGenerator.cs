using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DisneyMovies.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DisneyMovies.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(int id, string firstName, string userName)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var duration = _configuration["Jwt:ExpiresInMinutes"];
        var secretKey = _configuration["Jwt:key"];
        var audience = _configuration["Jwt:validAudience"];
        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), 
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            new Claim(JwtRegisteredClaimNames.Sid, id.ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: issuer,
            //audience: audience,
            expires: DateTime.UtcNow.AddDays(int.Parse(duration)),
            claims: claims,
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}