namespace Core.Models.Users
{
    public class UserUpdateOptions
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

        public bool? IsEnabled { get; set; }
        public bool? IsLocked { get; set; }
    }
}
