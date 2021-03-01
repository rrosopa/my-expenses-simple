using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Models.Expenses
{
    public class ExpenseEntity : BaseEntity
    {
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseTypeEntity ExpenseType { get; set; }

        public string Note { get; set; }

        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class ExpenseEntityMapping : IEntityTypeConfiguration<ExpenseEntity>
    {
        public void Configure(EntityTypeBuilder<ExpenseEntity> builder)
        {
            builder.ToTable("Expense"); // table name 
            MappingHelper.MapBaseEntity(builder);

            builder.Property(x => x.ExpenseTypeId).HasColumnName("ExpenseTypeId").IsRequired();
            builder.Property(x => x.Note).HasColumnName("Note").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

            builder.HasOne(x => x.ExpenseType).WithMany().HasForeignKey(x => x.ExpenseTypeId);
        }
    }
}
