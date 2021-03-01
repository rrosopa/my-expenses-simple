using Core.Models.ActionResults;
using Core.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers.API.V1
{
    /// <summary>
    /// endpoint for user functionalities
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// gets user data by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>ItemFetchResult</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FetchResult<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FetchResult<User>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserAsync(id);
            if (result.Errors.Any())
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}