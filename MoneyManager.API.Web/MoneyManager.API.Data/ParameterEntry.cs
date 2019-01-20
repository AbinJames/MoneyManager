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
        public long EntryId { get; set; }

        /// <summary>
        /// id of parameter for which amount was added
        /// </summary>
        public long? ParameterId { get; set; }
        public virtual Parameters Parameters { get; set; }

        /// <summary>
        /// Gets or sets the savings parameter identifier.
        /// </summary>
        /// <value>
        /// The savings parameter identifier.
        /// </value>
        public long? SavingsParameterId { get; set; }
        public virtual SavingsParameters SavingsParameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is savings parameter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is savings parameter; otherwise, <c>false</c>.
        /// </value>
        public bool IsSavingsParameter { get; set; }

        /// <summary>
        /// id of deposit from which balance was subtracted
        /// </summary>
        public long DepositId { get; set; }
        public virtual Deposit deposits { get; set; }

        /// <summary>
        /// Balance added for the parameter
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float AddedBalance { get; set; }
    }
}
