using Core.Models.ActionResults;
using Core.Models.Expenses;
using System.Threading.Tasks;

namespace Services.Expenses
{
    public interface IExpenseService
    {
        Task<FetchResult<ExpenseSummary>> GetExpenseSummaryAsync(int month);
        Task<SearchResult<Expense>> SearchAsync(ExpenseSearchOptions searchOptions);
    }
}
