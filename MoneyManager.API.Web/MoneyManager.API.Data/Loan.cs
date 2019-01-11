using MoneyManager.API.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager.API.Data
{
    /// <summary>
    /// This is used to hold records of loans that needs to be paid and loan that are to be recieved
    /// </summary>
    public class Loan : ILoan
    {
        /// <summary>
        /// id for loan
        /// </summary>
        [Key]
        public long LoanId { get; set; }

        /// <summary>
        /// details of loan
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LoanDetails { get; set; }

        /// <summary>
        /// person who is lending or owes the amount
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LoanPerson { get; set; }

        /// <summary>
        /// If loan is to you then true
        /// if you owe the loan then false
        /// </summary>
        [Required]
        public bool IsLoanOwedToYou { get; set; }

        /// <summary>
        /// If the loan has been completely paid then true, else false
        /// </summary>
        [Required]
        public bool IsLoanPayed { get; set; }

        /// <summary>
        /// Total Amount of loan that needs to be paid
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float LoanAmount { get; set; }

        /// <summary>
        /// Date on which loan was given
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime LoanStartDate { get; set; }

        /// <summary>
        /// Date by which loan needs to be paid
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime LoanEndDate { get; set; }
    }
}
