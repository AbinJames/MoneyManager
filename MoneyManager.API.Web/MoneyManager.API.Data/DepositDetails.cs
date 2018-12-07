using MoneyManager.API.Contracts.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.API.Data
{
    public class DepositDetails : IDepositDetails
    {
        /// <summary>
        /// Id for amount deposited
        /// </summary>
        [Key]
        public int depositId { get; set; }

        /// <summary>
        /// Source of money
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string depositSource { get; set; }

        /// <summary>
        /// Date money is deposited
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime depositDate { get; set; }

        /// <summary>
        /// Amount deposited
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float depositAmount { get; set; }
    }
}
