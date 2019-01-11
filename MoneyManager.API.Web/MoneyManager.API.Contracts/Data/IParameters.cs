using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// Parameters by which deposited amount is split
    /// </summary>
    public interface IParameters
    {
        long ParameterId { get; set; }
        
        string ParameterName { get; set; }
        
        float ParameterAmount { get; set; }
        
        float ParameterBalance { get; set; }
    }
}
