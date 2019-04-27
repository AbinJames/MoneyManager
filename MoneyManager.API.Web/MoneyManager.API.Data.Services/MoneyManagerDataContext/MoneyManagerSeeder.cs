using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.MoneyManagerData;

namespace MoneyManager.API.Data.Services.MoneyManagerDataContext
{
    /// <summary>
    /// Class containing initial data for database
    /// </summary>
    public static class MoneyManagerSeeder
    {
        /// <summary>
        /// Function iniializes database with data on migration
        /// </summary>
        /// <param name="modelBuilder">builder Parameter from context</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameters>().HasData(
                new Parameters { ParameterId = 1, ParameterName = "Groceries", ParameterAmount = 2000, ParameterBalance = 0 },
                new Parameters { ParameterId = 2, ParameterName = "Medical Expenses", ParameterAmount = 1000, ParameterBalance = 0 },
                new Parameters { ParameterId = 3, ParameterName = "Travel Expenses", ParameterAmount = 800, ParameterBalance = 0 },
                new Parameters { ParameterId = 4, ParameterName = "Utilities - Electricity", ParameterAmount = 2000, ParameterBalance = 0 },
                new Parameters { ParameterId = 5, ParameterName = "Movie", ParameterAmount = 500, ParameterBalance = 0 },
                new Parameters { ParameterId = 6, ParameterName = "Miscelleneous", ParameterAmount = 1000, ParameterBalance = 0 }
            );

            modelBuilder.Entity<SavingsParameters>().HasData(
                new SavingsParameters { SavingsParameterId = 1, SavingsParameterName = "Main Savings", SavingsParameterBalance = 0 },
                new SavingsParameters { SavingsParameterId = 2, SavingsParameterName = "Shopping", SavingsParameterBalance = 0 },
                new SavingsParameters { SavingsParameterId = 3, SavingsParameterName = "Loan", SavingsParameterBalance = 0 }
            );
        }
    }
}
