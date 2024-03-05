namespace OptiCore.Domain.Core
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        // Add any other properties or methods specific to your tenant control logic
    }
}