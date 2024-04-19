using API.Authenticate.JWT.Interfaces;
using API.Authenticate.JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Authenticate.JWT.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public string GetToken(User user)
        {
            var token = string.Empty;
            
            var existsUser = UserList.users.Where(x => x.Name == user.Name).FirstOrDefault();
            if (existsUser == null)
                return token;

            
            if (existsUser.Password != user.Password)
                return token;

            var cryptographyKey = Encoding.ASCII.GetBytes(_configuration["SecretJWT"]);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenProperties = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.AllowedLevel.ToString()),
                    new Claim("Date", $"{DateTime.Now:yyy-MM-dd}"),
                }
                ),
                Expires = DateTime.UtcNow.AddHours(24),
                // Adiciona a chave de criptografia
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(cryptographyKey),
                                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenProperties);
            token = tokenHandler.WriteToken(securityToken);
            
            return token;

        }
    }
}
