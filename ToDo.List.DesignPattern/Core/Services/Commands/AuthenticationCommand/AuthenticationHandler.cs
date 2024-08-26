using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.AuthenticationCommand;

public class AuthenticationHandler(IConfiguration configuration, IEFRepository<User> userRepository) : IRequestHandler<AuthenticationCommand, string>
{
    public async Task<string> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(configuration["PrivateKey"]);

        var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials,
        };
        
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}