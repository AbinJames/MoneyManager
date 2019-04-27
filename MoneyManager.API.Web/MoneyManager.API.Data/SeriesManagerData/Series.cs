using MoneyManager.API.Contracts.SeriesData;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.API.Data.SeriesManagerData
{
    public class Series : ISeries
    {
        [Key]
        public long SeriesId { get; set; }

        public long ApiId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string SeriesName { get; set; }
    }
}
