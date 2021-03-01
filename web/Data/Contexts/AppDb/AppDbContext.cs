using Data.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts.AppDb
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //public DbSet<ExpenseEntity> Users { get; set; }
        public virtual DbSet<ExpenseEntity> Expenses { get; set; }
        public virtual DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new UserEntityMapping());
            builder.ApplyConfiguration(new ExpenseEntityMapping());
            builder.ApplyConfiguration(new ExpenseTypeEntityMapping());
        }
    }
}
