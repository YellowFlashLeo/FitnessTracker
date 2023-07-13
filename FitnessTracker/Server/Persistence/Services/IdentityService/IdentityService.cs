using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FitnessTracker.Server.Persistence.Services.IdentityService
{
    public class IdentityService : IIdentityService
    {
        private readonly FitnessStoreContext _dbContext;
        private readonly UserManager<FitnessAppUser> _userManager;

        public IdentityService(FitnessStoreContext dbContext, UserManager<FitnessAppUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<bool>> doCredentialsMatch(string userName, string password)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            if (user.Equals(null))
            {
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    Message = "You are not registered",
                    Success = false
                };
            }
            
            var result = user.Password.Equals(password);
            if (!result)
            {
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    Message = "Password does not match",
                    Success = false
                };
            }

            return new ServiceResponse<bool>()
            {
                Data = true,
                Message = "Welcome back!",
                Success = true
            };
        }

        public async Task<ServiceResponse<AuthenticatingUser>> GetUserDetails(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var userCredentials = new AuthenticatingUser
                {
                    Email = user.Email,
                    Password = user.Password
                };

                return new ServiceResponse<AuthenticatingUser>
                {
                    Data = userCredentials,
                    Success = true
                };
            }

            return new ServiceResponse<AuthenticatingUser>
            {
                Success = false
            };
        }

        public async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var roles = from ur in _dbContext.UserRoles
                join r in _dbContext.Roles on ur.RoleId equals r.Id
                where ur.UserId == user.Id
                select new { ur.UserId, ur.RoleId, r.Name };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf,
                    new DateTimeOffset(DateTime.Now)
                        .ToUnixTimeSeconds()
                        .ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                    new DateTimeOffset(DateTime.Now.AddHours(2))
                        .ToUnixTimeSeconds()
                        .ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecret")),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));


            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };
           
            return output;
        }

        public async Task<ServiceResponse<List<Gender>>> GetGenders()
        {
            var genders = await _dbContext.Genders.ToListAsync();
            return new ServiceResponse<List<Gender>>
            {
                Data = genders
            };
        }
    }
}
