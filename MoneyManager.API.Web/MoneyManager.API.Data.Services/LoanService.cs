using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyManager.API.Data.Services
{
    class LoanService
    {
        private readonly MoneyManagerContext moneyManagerContext;

        /// <summary>
        /// Get application db context
        /// </summary>
        /// <param name="context">
        /// database context
        /// </param>
        public LoanService(MoneyManagerContext context)
        {
            moneyManagerContext = context;
        }

        /// <summary>
        /// Get list of loan details
        /// </summary>
        /// <returns>list of loan details</returns>
        public IEnumerable<Loan> GetLoans()
        {
            return moneyManagerContext.Loan;
        }

        /// <summary>
        /// Adds loan details to database
        /// </summary>
        /// <param name="Loan">
        /// All details stored as class object
        /// </param>
        public void AddLoan(Loan loan)
        {
            moneyManagerContext.Loan.Add(loan);
            moneyManagerContext.SaveChanges();
        }

        /// <summary>
        /// Function to add current payment of loan to database
        /// </summary>
        /// <param name="loanPayment"></param>
        public void AddLoanPayment(LoanPayment loanPayment)
        {
            moneyManagerContext.LoanPayment.Add(loanPayment);
            var loan = moneyManagerContext.Loan.Find(loanPayment.loanId);
            //total amount payed or recieved for loan
            var totalPayed = moneyManagerContext.LoanPayment.Where(entry=>entry.loanId == loanPayment.loanId).Sum(entry => entry.loanPaymentAmount);
            if(totalPayed>=loan.loanAmount)
            {
                //set payed =true is whole amount is payed or received
                loan.isLoanPayed = true;
            }
            moneyManagerContext.Entry(loan).State = EntityState.Modified;
            moneyManagerContext.SaveChanges();
        }
    }
}
