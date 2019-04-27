namespace MoneyManager.API.Contracts.SeriesData
{
    public interface ISeries
    {
        long SeriesId { get; set; }

        string SeriesName { get; set; }
    }
}
