using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.API.Data.Services
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
            //Get parameter details from database and update balance
            Parameters parameter = moneyManagerContext.Parameters.Where(item => item.parameterId == expense.parameterId).FirstOrDefault<Parameters>();
            parameter.parameterBalance = parameter.parameterBalance - expense.expenseAmount;
            moneyManagerContext.Entry(parameter).State = EntityState.Modified;
            moneyManagerContext.SaveChanges();
        }
    }
}
