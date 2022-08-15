using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DisneyMovies.Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DisneyMovies.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(int id, string firstName, string userName)
    {
        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyMost-SecureKey")), 
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            new Claim(JwtRegisteredClaimNames.Sid, id.ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: "DisneyWebApi",
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}