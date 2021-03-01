using Core.Constants;
using Core.Extensions;
using Core.Models.ActionResults;
using Core.Models.Auth;
using Core.Models.Errors;
using Data.Constants;
using Data.Contexts.AppDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class AutheticationService : IAuthenticationService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AutheticationService> _logger;

        public AutheticationService(
            IAppDbContext appDbContext,
            ILogger<AutheticationService> logger)
        {            
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<ActionResult<AuthenticationResult>> AuthenticateAsync(AuthenticationOptions authenticationDetails)
        {
            var result = new ActionResult<AuthenticationResult>();

            try
            {
                // NOTE: grant is just an additional measure, its like a secret key
                if (authenticationDetails.Grant != authenticationDetails.AppSettingsGrant)
                    return null;

                var userDetails = await _appDbContext.Users
                                    .Where(user => user.Email == authenticationDetails.Username && user.IsEnabled)
                                    ?.Select(user => new 
                                    { 
                                        user.Id, 
                                        user.PasswordHash,
                                        user.IsLocked
                                    })
                                    ?.SingleOrDefaultAsync();

                if(userDetails?.Id == DbDefaults.SystemAdminId && !userDetails.PasswordHash.HasValue())
                {
                    // do something here...
                }

                if (userDetails == null || !VerifyPassword(authenticationDetails.Password, userDetails.PasswordHash))
                {
                    result.Errors.Add(new Error(ErrorCode.AuthenticationService001, "Invalid username or password."));
                }
                else if (userDetails.IsLocked)
                {
                    result.Errors.Add(new Error(ErrorCode.AuthenticationService002, "Your account has been locked, contact your administrator to get more details."));
                }
                else
                {
                    result.Result = new AuthenticationResult
                    {
                        UserId = userDetails.Id,
                        Token = BuildToken(userDetails.Id, authenticationDetails.Username, authenticationDetails.Password, authenticationDetails.JwtExpirationInMinutes)
                    };
                }                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"[{ErrorCode.AuthenticationService003}] {ex.Message}");
                result.Errors.Add(new Error(ErrorCode.AuthenticationService003));
            }

            return result;
        }

        // ref: https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var hash = ComputeHash(salt, password);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string inputPassword, string storedPassword)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(storedPassword);

            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var hash = ComputeHash(salt, inputPassword);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;

            return true;
        }

        private byte[] ComputeHash(byte[] salt, string password)
        {
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            return pbkdf2.GetBytes(20);
        }

        private string BuildToken(int userId, string jwtKey, string jwtIssuer, int jwtExpirationInMinutes)
        {
            // NOTE: avoid putting irrelevant claims, user Id goes a long way
            var claims = new[]
            {
                new Claim(AppClaimType.UserId, userId.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtIssuer,
                claims,
                expires: DateTime.Now.AddMinutes(jwtExpirationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
