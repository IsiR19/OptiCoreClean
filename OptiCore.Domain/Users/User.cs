namespace OptiCore.Domain.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Add any other properties specific to a user

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}