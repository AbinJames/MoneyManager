namespace MoneyManager.API.Contracts.Data
{
    public interface ISavingsParameters
    {
        long SavingsParameterId { get; set; }

        string SavingsParameterName { get; set; }

        float SavingsParameterBalance { get; set; }
    }
}
