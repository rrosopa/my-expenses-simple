namespace Core.Models.Auth
{
    public class AuthenticationOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Grant { get; set; }

        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpirationInMinutes { get; set; }
        public string AppSettingsGrant { get; set; }
    }
}
