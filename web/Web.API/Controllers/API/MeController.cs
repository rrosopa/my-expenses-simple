using Core.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Web.API.Controllers.API
{
    /// <summary>
    /// endpoint for getting data with regards to current user
    /// </summary>
    //[Authorize]
    [ApiVersionNeutral]
    [Route("api/me")]
    [ApiController]
    public class MeController : ControllerBase
    {
        private readonly ILogger<MeController> _logger;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        public MeController(ILogger<MeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// gets current user details, such as email, name, age, etc...
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            _logger.LogInformation("This is a test log. :)");
            var user = new User();
            var prop = user.GetType().GetProperty("FirstName");
            if (prop != null)
                prop.SetValue(user, "Me");
            
            return Ok(user);
        }
    }
}