using Core.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.API.Controllers.API.V2
{
    /// <summary>
    /// endpoint for user functionalities
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// gets user data by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>ItemFetchResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(new User() { FirstName = "number 2" });
        }
    }
}