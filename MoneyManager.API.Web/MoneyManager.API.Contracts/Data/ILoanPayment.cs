using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to hold record of payment of loan amount
    /// </summary>
    public interface ILoanPayment
    {
        /// <summary>
        /// id for loan
        /// </summary>
        int loanPaymentId { get; set; }

        /// <summary>
        /// Loan id for which the amount is payed
        /// </summary>
        int loanId { get; set; }

        /// <summary>
        /// Total Amount of loan that needs to be paid
        /// </summary>
        float loanPaymentAmount { get; set; }

        /// <summary>
        /// Date on which amount was given or recieved
        /// </summary>
        DateTime loanPaymentDate { get; set; }
    }
}
