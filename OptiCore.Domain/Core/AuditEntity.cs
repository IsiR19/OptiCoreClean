namespace OptiCore.Domain.Core
{
    public abstract class AuditEntity : BaseEntity
    {
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}