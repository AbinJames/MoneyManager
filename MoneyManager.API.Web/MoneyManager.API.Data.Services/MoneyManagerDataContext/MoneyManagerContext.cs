using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.MoneyManagerData;

namespace MoneyManager.API.Data.Services.MoneyManagerDataContext
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

        /// <summary>
        /// Gets or sets the deposit.
        /// </summary>
        /// <value>
        /// The deposit.
        /// </value>
        public DbSet<Deposit> Deposit { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public DbSet<Parameters> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the parameter entry.
        /// </summary>
        /// <value>
        /// The parameter entry.
        /// </value>
        public DbSet<ParameterEntry> ParameterEntry { get; set; }

        /// <summary>
        /// Gets or sets the expense.
        /// </summary>
        /// <value>
        /// The expense.
        /// </value>
        public DbSet<Expense> Expense { get; set; }

        /// <summary>
        /// Gets or sets the loan.
        /// </summary>
        /// <value>
        /// The loan.
        /// </value>
        public DbSet<Loan> Loan { get; set; }

        /// <summary>
        /// Gets or sets the loan payment.
        /// </summary>
        /// <value>
        /// The loan payment.
        /// </value>
        public DbSet<LoanPayment> LoanPayment { get; set; }

        /// <summary>
        /// Gets or sets the savings parameters.
        /// </summary>
        /// <value>
        /// The savings parameters.
        /// </value>
        public DbSet<SavingsParameters> SavingsParameters { get; set; }

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
