using Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;



namespace CubaAds.Services.TokenServices
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateTokens(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            

            var claims = new[]
            {
                
                new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                new Claim(ClaimTypes.Role, user.rol.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.email)
            };


            //una forma mas flexible a la hora de crear los tokens
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject =  new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = creds
            };

            //esta forma decrear tokens es mas directa
           /* var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);*/ //con esta via se crea el token directamente y luego se convierte a string

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescription);//se crea primero el descriptor
            return new JwtSecurityTokenHandler().WriteToken(token);//luego se genera el string
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
