using MoneyManager.API.Contracts.SeriesManagerData;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.API.Data.SeriesManagerData
{
    public class Comics : IComics
    {
        [Key]
        public long ComicsId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ComicsName { get; set; }
    }
}
