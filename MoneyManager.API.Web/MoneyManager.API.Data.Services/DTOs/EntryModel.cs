using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Data.Services.DTOs
{
    public class EntryModel
    {
        /// <summary>
        /// Id for each entry
        /// </summary>
        public int entryId { get; set; }

        /// <summary>
        /// Name of parameter for which amount was added
        /// </summary>
        public string parameterName { get; set; }

        /// <summary>
        /// Balance added for the parameter
        /// </summary>
        public float addedBalance { get; set; }
    }
}
