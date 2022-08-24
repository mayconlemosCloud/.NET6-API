using Domain.core.Token;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class ServiceToken : IServiceToken
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceToken(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public string GenerateToken(User user)
        {
            var userValidate = _repositoryUser.Get(user.Email, user.Password);

            if (userValidate == null)
                return "Usuário ou senha inválidos";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.Secret());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userValidate.Email.ToString()),
                    new Claim(ClaimTypes.Role, userValidate.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenGenerated = tokenHandler.WriteToken(token);
            return tokenGenerated.ToString();
        }
    }
}