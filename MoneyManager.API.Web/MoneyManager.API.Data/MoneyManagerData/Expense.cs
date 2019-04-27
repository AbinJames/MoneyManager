using MoneyManager.API.Contracts.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.API.Data.MoneyManagerData
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
        public long ExpenseId { get; set; }

        /// <summary>
        /// Additional details related to expense
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ExpenseDetails { get; set; }

        [Required]
        public bool IsSavingsParameter { get; set; }

        public long? SavingsParameterId { get; set; }
        public virtual SavingsParameters SavingsParameters { get; set; }

        /// <summary>
        /// id of parameter for which amount was spend
        /// </summary>
        public long? ParameterId { get; set; }
        public virtual Parameters Parameters { get; set; }

        /// <summary>
        /// Date money is spend
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// Estimated time when amount was spend
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        public DateTime ExpenseTime { get; set; }

        /// <summary>
        /// Amount spend
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float ExpenseAmount { get; set; }
    }
}
