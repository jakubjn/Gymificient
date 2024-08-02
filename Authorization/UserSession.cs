namespace GymSystem.Authorization
{
    public class UserSession
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = "Guest";
        public string Password { get; set; }
        public string Role { get; set; } = "guest";
        public Guid OrgId { get; set; }
    }
}
