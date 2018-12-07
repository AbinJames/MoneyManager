using MoneyManager.API.Data.Services.Context;
using System;
using System.Collections.Generic;

namespace MoneyManager.API.Data.Services
{
    public class DepositService
    {
        private readonly MoneyManagerContext moneyManagerContext;

        /// <summary>
        /// Get application db context
        /// </summary>
        /// <param name="context">
        /// database context
        /// </param>
        public DepositService(MoneyManagerContext context)
        {
            moneyManagerContext = context;
        }

        /// <summary>
        /// returns values from database to be send to frontend
        /// </summary>
        /// <returns>list of deposit details</returns>
        public IEnumerable<DepositDetails> GetDepositDetails()
        {
            return moneyManagerContext.DepositDetails;
        }

        /// <summary>
        /// Adds deposit details to database
        /// </summary>
        /// <param name="depositDetails">
        /// All details stored as class object
        /// </param>
        public void AddDepositDetails(DepositDetails depositDetails)
        {
            moneyManagerContext.DepositDetails.Add(depositDetails);
            moneyManagerContext.SaveChanges();
        }
    }
}
