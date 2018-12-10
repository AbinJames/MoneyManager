using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Contracts.Data
{
    public interface IDepositDetails
    {
        /// <summary>
        /// Id for amount deposited
        /// </summary>
        int depositId { get; set; }

        /// <summary>
        /// Source of money
        /// </summary>
        string depositSource { get; set; }

        /// <summary>
        /// Date money is deposited
        /// </summary>
        DateTime depositDate { get; set; }

        /// <summary>
        /// Estimated time when amount was deposited
        /// </summary>
        DateTime depositTime { get; set; }

        /// <summary>
        /// Amount deposited
        /// </summary>
        float depositAmount { get; set; }
    }
}
