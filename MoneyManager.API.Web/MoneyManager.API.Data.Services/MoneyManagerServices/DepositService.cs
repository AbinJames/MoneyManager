using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.MoneyManagerData;
using MoneyManager.API.Data.Services.MoneyManagerDataContext;
using MoneyManager.API.Data.Services.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.API.Data.Services.MoneyManagerServices
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
                             join parameter in moneyManagerContext.Parameters
                             on entry.ParameterId equals parameter.ParameterId
                             select new EntryModel()
                             {
                                 EntryId = entry.EntryId,
                                 ParameterName = parameter.ParameterName,
                                 AddedBalance = entry.AddedBalance
                             }
                             ).ToList();

            //Get list of deposits and correspnding entries in entryList
            return from deposit in moneyManagerContext.Deposit
                   select new DepositModel()
                   {
                       DepositId = deposit.DepositId,
                       DepositAmount = deposit.DepositAmount,
                       DepositDate = deposit.DepositDate,
                       DepositTime = deposit.DepositTime,
                       DepositSource = deposit.DepositSource,
                       EntryModels = (from entryData in moneyManagerContext.ParameterEntry
                                      where entryData.DepositId == deposit.DepositId
                                      join parameter in moneyManagerContext.Parameters
                                      on entryData.ParameterId equals parameter.ParameterId
                                      select new EntryModel()
                                      {
                                          EntryId = entryData.EntryId,
                                          ParameterName = parameter.ParameterName,
                                          AddedBalance = entryData.AddedBalance
                                      }).ToList()
                   };
        }


        /// <summary>
        /// Adds deposit details to database
        /// </summary>
        /// <param name="depositDetails">
        /// All details stored as class object
        /// </param>
        public void AddDepositDetails(Deposit deposit)
        {
            moneyManagerContext.Deposit.Add(deposit);
            //get list of all parameters that have amount less than balane
            //order by balance with lowest first
            var parameterList = moneyManagerContext.Parameters
                                .Where(parameter => parameter.ParameterBalance < parameter.ParameterAmount)
                                .OrderBy(parameter => parameter.ParameterBalance)
                                .ToList();
            var balance = deposit.DepositAmount;
            //add amount to balance from deposit and save changes
            foreach (var parameter in parameterList)
            {
                var amountToBeAdded = parameter.ParameterAmount - parameter.ParameterBalance;
                var amountThatCanBeAdded = balance <= amountToBeAdded ? balance : amountToBeAdded;
                if (amountToBeAdded > (0.25 * parameter.ParameterAmount))
                {
                    ParameterEntry parameterEntry = new ParameterEntry()
                    {
                        ParameterId = parameter.ParameterId,
                        DepositId = deposit.DepositId,
                        AddedBalance = amountThatCanBeAdded,
                        IsSavingsParameter = false
                    };
                    moneyManagerContext.ParameterEntry.Add(parameterEntry);
                    parameter.ParameterBalance = parameter.ParameterBalance + amountThatCanBeAdded;
                    balance = balance - amountThatCanBeAdded;
                    moneyManagerContext.Entry(parameter).State = EntityState.Modified;
                }
            }
            var savingsParameterList = moneyManagerContext.SavingsParameters.ToList();
            foreach (var savingsParameter in savingsParameterList)
            {
                ParameterEntry parameterEntry = new ParameterEntry()
                {
                    SavingsParameterId = savingsParameter.SavingsParameterId,
                    DepositId = deposit.DepositId,
                    AddedBalance = balance / savingsParameterList.Count,
                    IsSavingsParameter = true
                };
                moneyManagerContext.ParameterEntry.Add(parameterEntry);
                savingsParameter.SavingsParameterBalance = savingsParameter.SavingsParameterBalance + (balance / savingsParameterList.Count);
                moneyManagerContext.Entry(savingsParameter).State = EntityState.Modified;
            }

            moneyManagerContext.SaveChanges();
        }
    }
}
