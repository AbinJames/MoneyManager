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
        /// <summary>
        /// Id for each entry
        /// </summary>
        int entryId { get; set; }

        /// <summary>
        /// id of parameter for which amount was added
        /// </summary>
        int parameterId { get; set; }

        /// <summary>
        /// id of deposit from which balance was subtracted
        /// </summary>
        int depositId { get; set; }

        /// <summary>
        /// Balance added for the parameter
        /// </summary>
        float addedBalance { get; set; }
    }
}
