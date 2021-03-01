using Core.Constants;
using Core.Extensions;
using Core.Models.ActionResults;
using Core.Models.Errors;
using Core.Models.Expenses;
using Data.Contexts.AppDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<ExpenseService> _logger;

        public ExpenseService(
            IAppDbContext appDbContext,
            ILogger<ExpenseService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }        

        public async Task<FetchResult<ExpenseSummary>> GetExpenseSummaryAsync(int month)
        {
            var result = new FetchResult<ExpenseSummary>
            {
                Result = new ExpenseSummary
                {
                    ExpenseTypes = new List<ExpenseTypeSummary>()
                }
            };

            try
            {                
                var expenses = await _appDbContext.Expenses.Where(x => x.Date.Month == month).GetAsync();
                var expenseTypes = await _appDbContext.ExpenseTypes.ToListAsync();

                foreach(var type in expenseTypes)
                {
                    result.Result.ExpenseTypes.Add(new ExpenseTypeSummary
                    {
                        ExpenseTypeId = type.Id,
                        ExpenseTypeName = type.Name,
                        TotalAmount = expenses.Where(x => x.ExpenseTypeId == type.Id)?.Sum(x => x.Amount) ?? 0
                    });
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[{ErrorCode.ExpenseService001}] {ex.Message}");
                result.Errors.Add(new Error(ErrorCode.ExpenseService001));
            }

            return result;
        }
        

        public async Task<SearchResult<Expense>> SearchAsync(ExpenseSearchOptions searchOptions)
        {
            var result = new SearchResult<Expense>
            {
                Page = searchOptions.Page,
                PageSize = searchOptions.PageSize
            };

            try
            {
                if (searchOptions == null)
                    return result;

                var query = _appDbContext.Expenses.AsQueryable();
                if (searchOptions.DateFrom.HasValue)
                    query = query.Where(x => x.Date >= searchOptions.DateFrom.Value);

                if (searchOptions.DateTo.HasValue)
                    query = query.Where(x => x.Date <= searchOptions.DateTo.Value);

                if (searchOptions.ExpenseTypeId.HasValue)
                    query = query.Where(x => x.ExpenseTypeId == searchOptions.ExpenseTypeId.Value);

                query = query.OrderByDescending(x => x.Date);
                result.TotalResult = await query.CountAsync();
                result.Result = await query.TakeItems(searchOptions.Page, searchOptions.PageSize).GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[{ErrorCode.ExpenseService002}] {ex.Message}");
                result.Errors.Add(new Error(ErrorCode.ExpenseService002));
            }

            return result;
        }
    }
}
