﻿using MoneyManager.API.Data.Services.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Data.Services
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
        public IEnumerable<Parameters> GetAmountSplitParameters()
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