using MoneyManager.API.Data.MoneyManagerData;
using MoneyManager.API.Data.Services.MoneyManagerDataContext;
using System.Collections.Generic;

namespace MoneyManager.API.Data.Services.MoneyManagerServices
{
    public class ParameterService
    {
        private readonly MoneyManagerContext moneyManagerContext;

        /// <summary>
        /// Get application db context
        /// </summary>
        /// <param name="context">
        /// database context
        /// </param>
        public ParameterService(MoneyManagerContext context)
        {
            moneyManagerContext = context;
        }

        /// <summary>
        /// Get list of parameters and their amounts
        /// </summary>
        /// <returns>list of parameters</returns>
        public IEnumerable<Parameters> GetParameters()
        {
            return moneyManagerContext.Parameters;
        }

        /// <summary>
        /// Adds parameter details to database
        /// </summary>
        /// <param name="Parameters">
        /// All details stored as class object
        /// </param>
        public void AddParameter(Parameters parameter)
        {
            moneyManagerContext.Parameters.Add(parameter);
            moneyManagerContext.SaveChanges();
        }
    }
}
