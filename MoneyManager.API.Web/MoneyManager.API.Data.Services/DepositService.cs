using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.Services.Context;
using MoneyManager.API.Data.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <returns>list of deposit details in DepositModel form</returns>
        public IEnumerable<DepositModel> GetDepositDetails()
        {
            //Get list of entries and store in ParameterModel
            var entryList = (from entry in moneyManagerContext.ParameterEntry
                             join parameter in moneyManagerContext.AmountSplitParameters
                             on entry.parameterId equals parameter.parameterId
                             select new EntryModel()
                             {
                                 entryId = entry.entryId,
                                 parameterName = parameter.parameterName,
                                 addedBalance = entry.addedBalance
                             }
                             ).ToList();

            //Get list of deposits and correspnding entries in entryList
            return from deposit in moneyManagerContext.DepositDetails
                   select new DepositModel()
                   {
                       depositId = deposit.depositId,
                       depositAmount = deposit.depositAmount,
                       depositDate = deposit.depositDate,
                       depositTime = deposit.depositTime,
                       depositSource = deposit.depositSource,
                       entryModels = (from entryData in moneyManagerContext.ParameterEntry
                                      where entryData.depositId == deposit.depositId
                                      join parameter in moneyManagerContext.AmountSplitParameters
                                      on entryData.parameterId equals parameter.parameterId
                                      select new EntryModel()
                                      {
                                          entryId = entryData.entryId,
                                          parameterName = parameter.parameterName,
                                          addedBalance = entryData.addedBalance
                                      }).ToList()
                   };
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
            //get list of all parameters that have amount less than balane
            //order by balance with lowest first
            var parameterList = moneyManagerContext.AmountSplitParameters
                                .Where(parameter => parameter.parameterBalance < parameter.parameterAmount)
                                .OrderBy(parameter => parameter.parameterBalance)
                                .ToList();
            var balance = depositDetails.depositAmount;
            //add amount to balance from deposit and save changes
            foreach (var parameter in parameterList)
            {
                if ((balance - parameter.parameterAmount) >= 0)
                {
                    ParameterEntry parameterEntry = new ParameterEntry()
                    {
                        parameterId = parameter.parameterId,
                        depositId = depositDetails.depositId,
                        addedBalance = parameter.parameterAmount - parameter.parameterBalance
                    };
                    moneyManagerContext.ParameterEntry.Add(parameterEntry);
                    parameter.parameterBalance = parameter.parameterBalance + (parameter.parameterAmount - parameter.parameterBalance);
                    balance = balance - (parameter.parameterAmount - parameter.parameterBalance);
                    moneyManagerContext.Entry(parameter).State = EntityState.Modified;
                }
            }
            moneyManagerContext.SaveChanges();
        }
    }
}
