namespace Watermeter.Project.API.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
