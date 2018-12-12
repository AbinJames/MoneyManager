using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to hold records of loans that needs to be paid and loan that are to be recieved
    /// </summary>
    public interface ILoan
    {
        /// <summary>
        /// id for loan
        /// </summary>
        int loanId { get; set; }

        /// <summary>
        /// details of loan
        /// </summary>
        string loanDetails { get; set; }

        /// <summary>
        /// person who is lending or owes the amount
        /// </summary>
        string loanPerson { get; set; }

        /// <summary>
        /// If loan is to you then true
        /// if you owe the loan then false
        /// </summary>
        Boolean isLoanOwedToYou { get; set; }

        /// <summary>
        /// If the loan has been completely paid then true, else false
        /// </summary>
        Boolean isLoanPayed { get; set; }

        /// <summary>
        /// Total Amount of loan that needs to be paid
        /// </summary>
        float loanAmount { get; set; }

        /// <summary>
        /// Date on which loan was given
        /// </summary>
        DateTime loanStartDate { get; set; }

        /// <summary>
        /// Date by which loan needs to be paid
        /// </summary>
        DateTime loanEndDate { get; set; }
    }
}
