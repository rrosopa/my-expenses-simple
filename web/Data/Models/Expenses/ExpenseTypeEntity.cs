using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Expenses
{
    public class ExpenseTypeEntity : BaseEntity
    {
        public string Name { get; set; }        
    }

    public class ExpenseTypeEntityMapping : IEntityTypeConfiguration<ExpenseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ExpenseTypeEntity> builder)
        {
            builder.ToTable("ExpenseType"); // table name 
            MappingHelper.MapBaseEntity(builder);
            
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        }
    }
}
