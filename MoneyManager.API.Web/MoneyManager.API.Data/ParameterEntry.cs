using MoneyManager.API.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager.API.Data
{
    /// <summary>
    /// This is used to hold the record of when and how much amount has been added from deposit
    /// to parameter balance
    /// </summary>
    public class ParameterEntry : IParameterEntry
    {
        /// <summary>
        /// Id for each entry
        /// </summary>
        [Key]
        public int entryId { get; set; }

        /// <summary>
        /// id of parameter for which amount was added
        /// </summary>
        public int parameterId { get; set; }
        public virtual AmountSplitParameters amountSplitParameters { get; set; }

        /// <summary>
        /// id of deposit from which balance was subtracted
        /// </summary>
        public int depositId { get; set; }
        public virtual DepositDetails depositDetails { get; set; }

        /// <summary>
        /// Balance added for the parameter
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float addedBalance { get; set; }
    }
}
