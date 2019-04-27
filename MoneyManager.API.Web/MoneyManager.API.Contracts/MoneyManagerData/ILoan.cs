using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    /// <summary>
    /// This is used to hold records of loans that needs to be paid and loan that are to be recieved
    /// </summary>
    public interface ILoan
    {
        long LoanId { get; set; }
        
        string LoanDetails { get; set; }
        
        string LoanPerson { get; set; }
        
        bool IsLoanOwedToYou { get; set; }
        
        bool IsLoanPayed { get; set; }
        
        float LoanAmount { get; set; }
        
        DateTime LoanStartDate { get; set; }
        
        DateTime LoanEndDate { get; set; }
    }
}
