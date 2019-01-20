using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Data;
using MoneyManager.API.Data.Services;
using MoneyManager.API.Data.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Web.Controllers
{
    /// <summary>
    /// Controller for calling expense operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/Expense/")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private ExpenseService expenseService;
        public ExpenseController(MoneyManagerContext moneyManagerContext)
        {
            expenseService = new ExpenseService(moneyManagerContext);
        }

        /// <summary>
        /// Add expense details to database through service
        /// </summary>
        /// <param name="Expence">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddExpense")]
        public IActionResult AddExpenseDetails(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            expenseService.AddExpense(expense);
            return NoContent();
        }

        /// <summary>
        /// Gets list of expense details from database through service
        /// </summary>
        /// <returns>List of expense details</returns>
        [HttpGet]
        [Route("GetExpense")]
        public IEnumerable<Expense> GetExpenseDetails()
        {
            return expenseService.GetExpenses();
        }
    }
}
