using MoneyManager.API.Contracts.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.API.Data.MoneyManagerData
{
    public class Deposit : IDeposit
    {
        /// <summary>
        /// Id for amount deposited
        /// </summary>
        [Key]
        public long DepositId { get; set; }

        /// <summary>
        /// Source of money
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string DepositSource { get; set; }

        /// <summary>
        /// Date money is deposited
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepositDate { get; set; }

        /// <summary>
        /// Estimated time when amount was deposited
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        public DateTime DepositTime { get; set; }

        /// <summary>
        /// Amount deposited
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float DepositAmount { get; set; }
    }
}
