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
    [Route("api/MoneyManager/AmountSplitParameter/")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private ParameterService parameterService;
        public ParameterController(MoneyManagerContext moneyManagerContext)
        {
            parameterService = new ParameterService(moneyManagerContext);
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
