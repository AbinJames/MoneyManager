using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to hold record of payment of loan amount
    /// </summary>
    public interface ILoanPayment
    {
        long LoanPaymentId { get; set; }
        
        long LoanId { get; set; }
        
        float LoanPaymentAmount { get; set; }
        
        DateTime LoanPaymentDate { get; set; }
    }
}
