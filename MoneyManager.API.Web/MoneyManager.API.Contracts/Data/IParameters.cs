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
        /// <summary>
        /// id for each of the parameters
        /// </summary>
        int parameterId { get; set; }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        string parameterName { get; set; }

        /// <summary>
        /// Amount to be taken from deposit for parameter
        /// </summary>
        float parameterAmount { get; set; }

        /// <summary>
        /// Balance amount after division from deposit for parameter
        /// </summary>
        float parameterBalance { get; set; }
    }
}
