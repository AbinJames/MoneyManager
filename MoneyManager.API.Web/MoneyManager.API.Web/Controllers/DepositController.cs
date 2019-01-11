using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Data;
using MoneyManager.API.Data.Services;
using MoneyManager.API.Data.Services.Context;
using MoneyManager.API.Data.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Web.Controllers
{
    /// <summary>
    /// Controller for calling deposit operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/Deposit/")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private DepositService depositService;
        public DepositController(MoneyManagerContext moneyManagerContext)
        {
            depositService = new DepositService(moneyManagerContext);
        }

        /// <summary>
        /// Add deposit details to database through service
        /// </summary>
        /// <param name="deposit">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddDeposit")]
        public IActionResult AddDepositDetails(Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            depositService.AddDepositDetails(deposit);
            return NoContent();
        }

        /// <summary>
        /// Gets list of deposit details from database through service
        /// </summary>
        /// <returns>List of deposit details</returns>
        [HttpGet]
        [Route("GetDeposit")]
        public IEnumerable<DepositModel> GetDepositDetails()
        {
            return depositService.GetDepositDetails();
        }
    }
}
