using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to save expense incurred based on various parameters from AmountSplitParameters
    /// </summary>
    public interface IExpense
    {
        /// <summary>
        /// Id for expense entry
        /// </summary>
        int expenseId { get; set; }

        /// <summary>
        /// Additional details related to expense
        /// </summary>
        string expenseDetails { get; set; }

        /// <summary>
        /// id of parameter for which amount was spend
        /// </summary>
        int parameterId { get; set; }

        /// <summary>
        /// Date money is spend
        /// </summary>
        DateTime expenseDate { get; set; }

        /// <summary>
        /// Estimated time when amount was spend
        /// </summary>
        DateTime expenseTime { get; set; }

        /// <summary>
        /// Amount spend
        /// </summary>
        float expenseAmount { get; set; }
    }
}
