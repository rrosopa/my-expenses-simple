using Core.Models.Expenses;
using Data.Models.Expenses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Queries
{
    internal static class ExpenseQuery
    {
        internal async static Task<List<Expense>> GetAsync(this IQueryable<ExpenseEntity> query)
        {
            return await query
                .Select(e => new Expense
                {
                    Id = e.Id,
                    ExpenseTypeId = e.ExpenseTypeId,
                    ExpenseTypeName = e.ExpenseType.Name,

                    Amount = e.Amount,
                    Date = e.Date,
                    Note = e.Note
                })
                .ToListAsync();
        }

        internal async static Task<Expense> GetAsync(this IQueryable<ExpenseEntity> query, int id) 
            => (await query.Where(e => e.Id == id).GetAsync()).SingleOrDefault();        
    }
}
