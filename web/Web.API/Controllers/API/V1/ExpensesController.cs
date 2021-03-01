using Core.Models.ActionResults;
using Core.Models.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Expenses;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers.API.V1
{
    /// <summary>
    /// 
    /// </summary>
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseService"></param>
        public ExpensesController(
            IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SearchResult<Expense>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SearchResult<Expense>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchExpensesAsync([FromQuery] ExpenseSearchOptions searchOptions)
        {
            var result = await _expenseService.SearchAsync(searchOptions);
            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("summary")]
        [ProducesResponseType(typeof(FetchResult<ExpenseSummary>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FetchResult<ExpenseSummary>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExpenseSummaryAsync([FromQuery] int month)
        {
            var result = await _expenseService.GetExpenseSummaryAsync(month);
            if (result.Errors.Any())
                return BadRequest(result);

            return Ok(result);
        }
    }
}