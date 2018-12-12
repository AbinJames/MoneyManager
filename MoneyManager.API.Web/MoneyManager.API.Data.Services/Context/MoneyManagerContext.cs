using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.API.Data.Services.Context
{
    public class MoneyManagerContext: DbContext
    {
        //Install-Package Microsoft.EntityFrameworkCore.SqlServer
        //Install-Package Microsoft.EntityFrameworkCore.Tools (for powershell commands)
        //Install-Package Microsoft.EntityFrameworkCore.Design
        //( contains migrations engine - and important note this package has to be inside executable project)
        public MoneyManagerContext(DbContextOptions<MoneyManagerContext> options) : base(options)
        {

        }

        //Set DbSet for following classes to access from database
        public DbSet<DepositDetails> DepositDetails { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<ParameterEntry> ParameterEntry { get; set; }
        public DbSet<Expense> Expense { get; set; }

        /// <summary>
        /// Function to execute action during data migrations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData(); // An extension method written specifically for adding the seed data
        }
    }
}
