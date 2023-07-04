using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MUIServer.Entities;
using MUIServer.Exceptions;
using MUIServer.Models;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MUIServer.Services
{

    public interface IAccountService
    {
        string GenerateJwt(LoginDTO loginDTO);
        void RegisterUser(RegisterUserDTO registerUserDTO);
    }

    public class AccountService : IAccountService
    {
        private readonly MainServerDbContext _mainServerDbContext;
        private readonly IPasswordHasher<ServerUser> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(MainServerDbContext mainServerDbContext, IPasswordHasher<ServerUser> passwordHasher, AuthenticationSettings authenticationSettings) 
        {
            _mainServerDbContext = mainServerDbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDTO registerUserDTO)
        {

            var newUser = new ServerUser()
            {
                EmailAddress = registerUserDTO.EmailAddress,
                BirthDate = registerUserDTO.BirthDate,
                UserName= registerUserDTO.UserName,
                PasswordHash = registerUserDTO.Password,
                Country = registerUserDTO.Country,
                RoleId = registerUserDTO.RoleId
            };

            var hashPassword = _passwordHasher.HashPassword(newUser, registerUserDTO.Password);

             newUser.PasswordHash = hashPassword;   
            _mainServerDbContext.Users.Add(newUser);
            _mainServerDbContext.SaveChanges();
        }
        
        public string GenerateJwt(LoginDTO loginDTO)
        {
            var user = _mainServerDbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(k => k.EmailAddress == loginDTO.EmailAddress);
            
            if(user is null)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.BirthDate.ToString("yyyy-MM-dd")),
                new Claim("Country", user.Country)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var keyExpire = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, claims, expires: keyExpire, signingCredentials: credencials);

            var tokenHandler = new JwtSecurityTokenHandler();
            
            return tokenHandler.WriteToken(token);
        }
    }
}
