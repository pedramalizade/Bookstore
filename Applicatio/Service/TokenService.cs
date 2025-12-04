

namespace Application.Service
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// تولید توکن JWT برای کاربر مشخص.
        /// </summary>
        /// <param name="user">کاربری که توکن برای آن تولید می‌شود.</param>
        /// <returns>توکن JWT به صورت رشته.</returns>
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
