using Core.Models.ActionResults;
using Core.Models.Auth;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface IAuthenticationService
    {
        Task<ActionResult<AuthenticationResult>> AuthenticateAsync(AuthenticationOptions authenticationDetails);        
    }
}
