using MoneyManager.API.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoneyManager.API.Data
{
    /// <summary>
    /// This is used to hold record of payment of loan amount
    /// </summary>
    public class LoanPayment: ILoanPayment
    {
        /// <summary>
        /// id for loan
        /// </summary>
        [Key]
        public int loanPaymentId { get; set; }

        /// <summary>
        /// Loan id for which the amount is payed
        /// </summary>
        public int loanId { get; set; }
        public virtual Loan loan { get; set; }

        /// <summary>
        /// Total Amount of loan that needs to be paid
        /// </summary>
        [Required]
        public float loanPaymentAmount { get; set; }

        /// <summary>
        /// Date on which amount was given or recieved
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime loanPaymentDate { get; set; }
    }
}
