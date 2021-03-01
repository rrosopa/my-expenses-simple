using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Models.Users
{
    public class UserEntity : AuditableEntity
    {
        public Guid PublicId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } 

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

        public bool IsEnabled { get; set; }
        public bool IsLocked { get; set; }

        public Guid ConcurrencyStamp { get; set; }
    }

    public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User"); // table name 
            MappingHelper.MapAuditableEntity(builder);

            builder.Property(x => x.PublicId).HasColumnName("PublicId").HasMaxLength(38).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(256);
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Email).HasColumnName("FirstName").IsRequired().HasMaxLength(256);
            builder.Property(x => x.PasswordHash).HasColumnName("MiddleName").IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).HasColumnName("LastName").IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).HasColumnName("Suffix").IsRequired().HasMaxLength(5);

            builder.Property(x => x.IsEnabled).HasColumnName("IsEnabled").IsRequired().HasDefaultValue(true);
            builder.Property(x => x.IsLocked).HasColumnName("IsLocked").IsRequired().HasDefaultValue(false);

            builder.Property(x => x.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }
    }
}
