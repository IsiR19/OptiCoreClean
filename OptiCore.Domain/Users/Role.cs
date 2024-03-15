namespace OptiCore.Domain.Users
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        // Add any other properties specific to a role

        public List<User> Users { get; set; } = new List<User>();
    }
}