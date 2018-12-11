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
        public int depositId { get; set; }

        /// <summary>
        /// Source of money
        /// </summary>
        public string depositSource { get; set; }

        /// <summary>
        /// Date money is deposited
        /// </summary>
        public DateTime depositDate { get; set; }

        /// <summary>
        /// Estimated time when amount was deposited
        /// </summary>
        public DateTime depositTime { get; set; }

        /// <summary>
        /// Amount deposited
        /// </summary>
        public float depositAmount { get; set; }

        /// <summary>
        /// List of entries for each deposit
        /// </summary>
        public IEnumerable<EntryModel> entryModels { get; set; }
    }
}
