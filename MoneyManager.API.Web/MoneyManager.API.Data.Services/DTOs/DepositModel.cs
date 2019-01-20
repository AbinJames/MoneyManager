using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Data.Services.DTOs
{
    /// <summary>
    /// This model is used to join data from DepositDetails, ParameterEntry, AmountSplitParameters
    /// </summary>
    public class DepositModel
    {
        /// <summary>
        /// Id for amount deposited
        /// </summary>
        public long DepositId { get; set; }

        /// <summary>
        /// Source of money
        /// </summary>
        public string DepositSource { get; set; }

        /// <summary>
        /// Date money is deposited
        /// </summary>
        public DateTime DepositDate { get; set; }

        /// <summary>
        /// Estimated time when amount was deposited
        /// </summary>
        public DateTime DepositTime { get; set; }

        /// <summary>
        /// Amount deposited
        /// </summary>
        public float DepositAmount { get; set; }

        /// <summary>
        /// List of entries for each deposit
        /// </summary>
        public IEnumerable<EntryModel> EntryModels { get; set; }
    }
}
