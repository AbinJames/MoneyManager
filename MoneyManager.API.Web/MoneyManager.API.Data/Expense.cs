using MoneyManager.API.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager.API.Data
{
    /// <summary>
    /// This is used to save expense incurred based on various parameters from AmountSplitParameters
    /// </summary>
    public class Expense: IExpense
    {
        /// <summary>
        /// Id for expense entry
        /// </summary>
        [Key]
        public int expenseId { get; set; }

        /// <summary>
        /// Additional details related to expense
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string expenseDetails { get; set; }

        /// <summary>
        /// id of parameter for which amount was spend
        /// </summary>
        public int parameterId { get; set; }
        public virtual Parameters amountSplitParameters { get; set; }

        /// <summary>
        /// Date money is spend
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime expenseDate { get; set; }

        /// <summary>
        /// Estimated time when amount was spend
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        public DateTime expenseTime { get; set; }

        /// <summary>
        /// Amount spend
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float expenseAmount { get; set; }
    }
}
