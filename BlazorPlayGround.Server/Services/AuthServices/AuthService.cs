
using Azure.Core;
using BlazorPlayGround.Shared.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlazorPlayGround.Server.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<UserLogin>> GetAllUser()
        {
            var users = await _context.Users
               .Include(p => p.UserDetails)
               .ToListAsync();
            return users;
        }

        public async Task<string> Login(LoginDTo request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.UserName == request.UserName.Trim());

            if (user == null)
            {
                return "No User Found";
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return "Wrong password.";
            }

            var token = CreateToken(user);

            return token;
        }


        public async Task<UserLogin> Register(UserLoginDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            UserLogin new_user = new UserLogin
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };

            UserDetails new_details = new UserDetails
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Contact = request.Contact,
                Address = request.Address,
                UserLogin = new_user,
                UserLoginId = new_user.Id
            };

            _context.Users.Add(new_user);
            _context.UsersDetails.Add(new_details);
            await _context.SaveChangesAsync();

            return new_user;
        }

        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(PasswordHash);
            }
        }
        public string CreateToken(UserLogin userLogin)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userLogin.UserName),
                new Claim(ClaimTypes.Role, userLogin.Role)
            };

            // 403 Don't have the Correct Role 
            // 401 No Autherization Header Set

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
