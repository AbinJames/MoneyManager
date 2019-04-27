using MoneyManager.API.Contracts.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.API.Data.MoneyManagerData
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
        public long LoanPaymentId { get; set; }

        /// <summary>
        /// Loan id for which the amount is payed
        /// </summary>
        public long LoanId { get; set; }
        public virtual Loan Loan { get; set; }

        /// <summary>
        /// Total Amount of loan that needs to be paid
        /// </summary>
        [Required]
        public float LoanPaymentAmount { get; set; }

        /// <summary>
        /// Date on which amount was given or recieved
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime LoanPaymentDate { get; set; }
    }
}
