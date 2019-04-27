using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.SeriesManagerData;

namespace MoneyManager.API.Data.Services.SeriesManagerDataContext
{
    public class SeriesManagerContext : DbContext
    {
        //For SQLServer
        //Install-Package Microsoft.EntityFrameworkCore.SqlServer
        //Install-Package Microsoft.EntityFrameworkCore.Tools (for powershell commands)
        //Install-Package Microsoft.EntityFrameworkCore.Design
        //( contains migrations engine - and important note this package has to be inside executable project)

        //For Postgres
        //Install NPGSQL.EntityFrameWorkCore.Postgres
        //Install NPGSQL.EntityFrameWorkCore.Postgres.Design

        public SeriesManagerContext(DbContextOptions<SeriesManagerContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>
        /// The series.
        /// </value>
        public DbSet<Series> Series { get; set; }

        /// <summary>
        /// Gets or sets the comics.
        /// </summary>
        /// <value>
        /// The comics.
        /// </value>
        public DbSet<Comics> Comics { get; set; }

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
