using Data.Models.Expenses;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contexts.AppDb
{
    public interface IAppDbContext
    {
        //DbSet<UserEntity> Users { get; set; }
        DbSet<ExpenseEntity> Expenses { get; set; }
        DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
