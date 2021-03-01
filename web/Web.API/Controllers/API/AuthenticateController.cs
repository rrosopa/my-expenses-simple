using Core.Models.Auth;
using Core.Models.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Auth;
using System.Threading.Tasks;

namespace Web.API.Controllers.API
{
    /// <summary>
    /// allow access to anyone, contains login/authentication endpoint
    /// </summary>
    [AllowAnonymous]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppSettings _settings;
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="authenticationService"></param>
        public AuthenticateController(
            IOptions<AppSettings> options,
            IAuthenticationService authenticationService)
        {
            _settings = options.Value;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="loginDetails">contains username, password and grant</param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDetails loginDetails)
        {
            var result = await _authenticationService.AuthenticateAsync(new AuthenticationOptions
            {
                Username = loginDetails.Username,
                Password = loginDetails.Password,
                Grant = loginDetails.Grant,

                JwtKey = _settings.Jwt.Key,
                JwtIssuer = _settings.Jwt.Issuer,
                JwtExpirationInMinutes = _settings.Jwt.ExpirationInMinutes,
                AppSettingsGrant = _settings.AppGrantType
            });

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}