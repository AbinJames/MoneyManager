using MoneyManager.API.Data.MoneyManagerData;
using MoneyManager.API.Data.Services.MoneyManagerDataContext;
using System.Collections.Generic;

namespace MoneyManager.API.Data.Services.MoneyManagerServices
{
    public class SavingsParameterService
    {
        private readonly MoneyManagerContext moneyManagerContext;

        /// <summary>
        /// Get application db context
        /// </summary>
        /// <param name="context">
        /// database context
        /// </param>
        public SavingsParameterService(MoneyManagerContext context)
        {
            moneyManagerContext = context;
        }

        /// <summary>
        /// Gets the savings parameters.
        /// </summary>
        /// <returns>list of savings parameters</returns>
        public IEnumerable<SavingsParameters> GetSavingsParameters()
        {
            return moneyManagerContext.SavingsParameters;
        }

        /// <summary>
        /// Adds the savings savingsParameter.
        /// </summary>
        /// <param name="savingsSavingsParameter">The savings Parameter.</param>
        public void AddSavingsParameter(SavingsParameters savingsParameter)
        {
            moneyManagerContext.SavingsParameters.Add(savingsParameter);
            moneyManagerContext.SaveChanges();
        }
    }
}
