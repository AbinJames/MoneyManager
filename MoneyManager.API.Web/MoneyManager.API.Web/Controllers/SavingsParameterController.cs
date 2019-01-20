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
    /// Controller for calling savingsParameter operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/SavingsParameters/")]
    [ApiController]
    public class SavingsParameterController : ControllerBase
    {
        private SavingsParameterService savingsParameterService;
        public SavingsParameterController(MoneyManagerContext moneyManagerContext)
        {
            savingsParameterService = new SavingsParameterService(moneyManagerContext);
        }

        /// <summary>
        /// Add savingsParameter details to database through service
        /// </summary>
        /// <param name="SavingsParameters">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddSavingsParameter")]
        public IActionResult AddParamter(SavingsParameters savingsParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            savingsParameterService.AddSavingsParameter(savingsParameter);
            return NoContent();
        }

        /// <summary>
        /// Get list of savingsParameters and their amounts from database through service
        /// </summary>
        /// <returns>list of savingsParameters</returns>
        [HttpGet]
        [Route("GetSavingsParameters")]
        public IEnumerable<SavingsParameters> GetSavingsParameters()
        {
            return savingsParameterService.GetSavingsParameters();
        }
    }
}
