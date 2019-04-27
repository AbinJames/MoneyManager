using MoneyManager.API.Contracts.Data;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.API.Data.MoneyManagerData
{
    public class SavingsParameters : ISavingsParameters
    {
        [Key]
        public long SavingsParameterId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string SavingsParameterName { get; set; }

        public float SavingsParameterBalance { get; set; }
    }
}
