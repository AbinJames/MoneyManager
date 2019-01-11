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
    public class Parameters: IParameters
    {
        /// <summary>
        /// id for each of the parameters
        /// </summary>
        [Key]
        public long ParameterId { get; set; }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ParameterName { get; set; }

        /// <summary>
        /// Amount to be taken from deposit for parameter
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float ParameterAmount { get; set; }

        /// <summary>
        /// Balance amount after division from deposit for parameter
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float ParameterBalance { get; set; }
    }
}
