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
    /// Controller for calling parameter operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/Parameters/")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private ParameterService parameterService;
        public ParameterController(MoneyManagerContext moneyManagerContext)
        {
            parameterService = new ParameterService(moneyManagerContext);
        }

        /// <summary>
        /// Add parameter details to database through service
        /// </summary>
        /// <param name="Parameters">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddParameter")]
        public IActionResult AddParamter(Parameters parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            parameterService.AddParameter(parameter);
            return NoContent();
        }

        /// <summary>
        /// Get list of parameters and their amounts from database through service
        /// </summary>
        /// <returns>list of parameters</returns>
        [HttpGet]
        [Route("GetParameters")]
        public IEnumerable<Parameters> GetAmountSplitParameters()
        {
            return parameterService.GetAmountSplitParameters();
        }
    }
}
