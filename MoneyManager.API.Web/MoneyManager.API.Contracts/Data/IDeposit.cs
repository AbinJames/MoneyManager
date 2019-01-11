using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    public interface IDeposit
    {
        long DepositId { get; set; }
        
        string DepositSource { get; set; }
        
        DateTime DepositDate { get; set; }
        
        DateTime DepositTime { get; set; }
        
        float DepositAmount { get; set; }
    }
}
