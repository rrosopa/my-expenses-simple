using System;

namespace Core.Models.Auth
{
    public class AuthenticationResult
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
