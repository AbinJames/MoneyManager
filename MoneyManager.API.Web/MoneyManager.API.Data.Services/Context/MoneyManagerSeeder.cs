using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Data.Services.Context
{
    /// <summary>
    /// Class containing initial data for database
    /// </summary>
    public static class MoneyManagerSeeder
    {
        /// <summary>
        /// Function iniializes database with data on migration
        /// </summary>
        /// <param name="modelBuilder">builder parameter from context</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountSplitParameters>().HasData(
                new AmountSplitParameters { parameterId = 1, parameterName = "Groceries", parameterAmount = 2000, parameterBalance = 0 },
                new AmountSplitParameters { parameterId = 2, parameterName = "Medical Expenses", parameterAmount = 1000, parameterBalance = 0 },
                new AmountSplitParameters { parameterId = 3, parameterName = "Travel Expenses", parameterAmount = 800, parameterBalance = 0 },
                new AmountSplitParameters { parameterId = 4, parameterName = "Utilities - Electricity", parameterAmount = 2000, parameterBalance = 0 },
                new AmountSplitParameters { parameterId = 5, parameterName = "Movie", parameterAmount = 500, parameterBalance = 0 },
                new AmountSplitParameters { parameterId = 6, parameterName = "Miscelleneous", parameterAmount = 1000, parameterBalance = 0 }
            );
        }
    }
}
