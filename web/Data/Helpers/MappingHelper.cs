using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Helpers
{
    public static class MappingHelper
    {
        public static void MapBaseEntity<T>(EntityTypeBuilder<T> builder, string idColumnName = "Id") where T : BaseEntity
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(idColumnName).IsRequired().ValueGeneratedOnAdd();            
        }

        public static void MapAuditableEntity<T>(EntityTypeBuilder<T> builder, string idColumnName = "Id") where T : AuditableEntity
        {
            MapBaseEntity(builder, idColumnName);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ModifiedDate).HasColumnName("LastModifiedDate").IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.CreatedById).HasColumnName("CreatedBy").IsRequired();
            builder.Property(x => x.ModifiedById).HasColumnName("LastModifiedBy").IsRequired();

            // ref
            builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
            builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById);
        }
    }
}
