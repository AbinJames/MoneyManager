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
                    parameterAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    parameterBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ParameterEntry",
                columns: table => new
                {
                    entryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    parameterId = table.Column<int>(nullable: false),
                    depositId = table.Column<int>(nullable: false),
                    addedBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterEntry", x => x.entryId);
                    table.ForeignKey(
                        name: "FK_ParameterEntry_DepositDetails_depositId",
                        column: x => x.depositId,
                        principalTable: "DepositDetails",
                        principalColumn: "depositId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterEntry_AmountSplitParameters_parameterId",
                        column: x => x.parameterId,
                        principalTable: "AmountSplitParameters",
                        principalColumn: "parameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AmountSplitParameters",
                columns: new[] { "parameterId", "parameterAmount", "parameterBalance", "parameterName" },
                values: new object[,]
                {
                    { 1, 2000m, 0m, "Groceries" },
                    { 2, 1000m, 0m, "Medical Expenses" },
                    { 3, 800m, 0m, "Travel Expenses" },
                    { 4, 2000m, 0m, "Utilities - Electricity" },
                    { 5, 500m, 0m, "Movie" },
                    { 6, 1000m, 0m, "Miscelleneous" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterEntry_depositId",
                table: "ParameterEntry",
                column: "depositId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterEntry_parameterId",
                table: "ParameterEntry",
                column: "parameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterEntry");

            migrationBuilder.DropTable(
                name: "DepositDetails");

            migrationBuilder.DropTable(
                name: "AmountSplitParameters");
        }
    }
}
