using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.MoneyManagerData;
using MoneyManager.API.Data.Services.MoneyManagerDataContext;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.API.Data.Services.MoneyManagerServices
{
    public class ExpenseService
    {
        private readonly MoneyManagerContext moneyManagerContext;

        /// <summary>
        /// Get application db context
        /// </summary>
        /// <param name="context">
        /// database context
        /// </param>
        public ExpenseService(MoneyManagerContext context)
        {
            moneyManagerContext = context;
        }

        /// <summary>
        /// Get list of expense details
        /// </summary>
        /// <returns>list of expense details</returns>
        public IEnumerable<Expense> GetExpenses()
        {
            return moneyManagerContext.Expense;
        }

        /// <summary>
        /// Adds expense details to database
        /// </summary>
        /// <param name="Expense">
        /// All details stored as class object
        /// </param>
        public void AddExpense(Expense expense)
        {
            moneyManagerContext.Expense.Add(expense);
            if (!expense.IsSavingsParameter)
            {
                //Get parameter details from database and update balance
                Parameters parameter = moneyManagerContext.Parameters.Where(item => item.ParameterId == expense.ParameterId).FirstOrDefault<Parameters>();
                parameter.ParameterBalance = parameter.ParameterBalance - expense.ExpenseAmount;
                moneyManagerContext.Entry(parameter).State = EntityState.Modified;
            }
            else
            {
                SavingsParameters savingsParameters = moneyManagerContext.SavingsParameters.Where(item => item.SavingsParameterId == expense.SavingsParameterId).FirstOrDefault<SavingsParameters>();
                savingsParameters.SavingsParameterBalance = savingsParameters.SavingsParameterBalance - expense.ExpenseAmount;
                moneyManagerContext.Entry(savingsParameters).State = EntityState.Modified;
            }
            moneyManagerContext.SaveChanges();
        }
    }
}
