using System;

namespace Core.Models
{
    public abstract class AuditableModel : BaseModel
    {
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public int ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
