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
        long ExpenseId { get; set; }
        
        string ExpenseDetails { get; set; }

        bool IsSavingsParameter { get; set; }
        
        long? ParameterId { get; set; }

        long? SavingsParameterId { get; set; }
        
        DateTime ExpenseDate { get; set; }
        
        DateTime ExpenseTime { get; set; }
        
        float ExpenseAmount { get; set; }
    }
}
