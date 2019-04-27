using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Data.MoneyManagerData;
using MoneyManager.API.Data.Services.MoneyManagerDataContext;
using MoneyManager.API.Data.Services.MoneyManagerServices;
using System.Collections.Generic;

namespace MoneyManager.API.Web.MoneyManagerControllers
{
    /// <summary>
    /// Controller for calling loan operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/Loan/")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private LoanService loanService;
        public LoanController(MoneyManagerContext moneyManagerContext)
        {
            loanService = new LoanService(moneyManagerContext);
        }

        /// <summary>
        /// Add loan details to database through service
        /// </summary>
        /// <param name="Loans">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddLoan")]
        public IActionResult AddParamter(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            loanService.AddLoan(loan);
            return NoContent();
        }

        /// <summary>
        /// Get list of loans and their amounts from database through service
        /// </summary>
        /// <returns>list of loans</returns>
        [HttpGet]
        [Route("GetLoans")]
        public IEnumerable<Loan> GetLoans()
        {
            return loanService.GetLoans();
        }
    }
}
