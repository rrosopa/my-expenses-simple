using Data.Models.Users;
using System;

namespace Data.Models
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public int CreatedById { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public int ModifiedById { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }


        public virtual UserEntity CreatedBy { get; set; }
        public virtual UserEntity ModifiedBy { get; set; }

    }
}
