using System.ComponentModel.DataAnnotations;

namespace OptiCore.Domain.Core
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
    }
}