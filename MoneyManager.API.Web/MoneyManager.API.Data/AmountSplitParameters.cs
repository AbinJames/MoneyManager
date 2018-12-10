using MoneyManager.API.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager.API.Data
{
    /// <summary>
    /// Parameters by which deposited amount is split
    /// </summary>
    public class AmountSplitParameters: IAmountSplitParameters
    {
        /// <summary>
        /// id for each of the parameters
        /// </summary>
        [Key]
        public int parameterId { get; set; }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string parameterName { get; set; }

        /// <summary>
        /// Amount to be taken from deposit for parameter
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float parameterAmount { get; set; }
    }
}
