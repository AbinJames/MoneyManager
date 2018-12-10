using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.API.Data.Services.Migrations
{
    public partial class MoneyManagerMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmountSplitParameters",
                columns: table => new
                {
                    parameterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    parameterName = table.Column<string>(maxLength: 60, nullable: false),
                    parameterAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountSplitParameters", x => x.parameterId);
                });

            migrationBuilder.CreateTable(
                name: "DepositDetails",
                columns: table => new
                {
                    depositId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    depositSource = table.Column<string>(maxLength: 60, nullable: false),
                    depositDate = table.Column<DateTime>(nullable: false),
                    depositTime = table.Column<DateTime>(nullable: false),
                    depositAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositDetails", x => x.depositId);
                });

            migrationBuilder.InsertData(
                table: "AmountSplitParameters",
                columns: new[] { "parameterId", "parameterAmount", "parameterName" },
                values: new object[,]
                {
                    { 1, 2000m, "Groceries" },
                    { 2, 1000m, "Medical Expenses" },
                    { 3, 800m, "Travel Expenses" },
                    { 4, 2000m, "Utilities - Electricity" },
                    { 5, 500m, "Movie" },
                    { 6, 1000m, "Miscelleneous" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountSplitParameters");

            migrationBuilder.DropTable(
                name: "DepositDetails");
        }
    }
}
