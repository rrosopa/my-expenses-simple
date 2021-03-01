using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Services.Auth
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal CurrentUser() => _httpContextAccessor.HttpContext.User;
        private string GetUserClaim(string claimType) => CurrentUser()?.FindFirst(claimType)?.Value;

        public string UserId => GetUserClaim(ClaimTypes.NameIdentifier);
    }
}
