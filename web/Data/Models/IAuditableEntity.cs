using Data.Models.Users;
using System;

namespace Data.Models
{
    public interface IAuditableEntity : IBaseEntity
    {
        int CreatedById { get; set; }
        DateTimeOffset CreatedDate { get; set; }

        int ModifiedById { get; set; }
        DateTimeOffset ModifiedDate { get; set; }

        UserEntity CreatedBy { get; set; }
        UserEntity ModifiedBy { get; set; }
    }
}
