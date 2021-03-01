using System;

namespace Data.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
