using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to hold the record of when and how much amount has been added from deposit
    /// to parameter balance
    /// </summary>
    public interface IParameterEntry
    {
        long EntryId { get; set; }
        
        long? ParameterId { get; set; }
        
        long? SavingsParameterId { get; set; }
        
        bool IsSavingsParameter { get; set; }
        
        long DepositId { get; set; }
        
        float AddedBalance { get; set; }
    }
}
