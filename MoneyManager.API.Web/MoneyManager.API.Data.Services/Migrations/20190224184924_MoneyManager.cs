using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoneyManager.API.Data.Services.Migrations
{
    public partial class MoneyManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    DepositId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DepositSource = table.Column<string>(maxLength: 60, nullable: false),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    DepositTime = table.Column<DateTime>(nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.DepositId);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    LoanId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LoanDetails = table.Column<string>(maxLength: 60, nullable: false),
                    LoanPerson = table.Column<string>(maxLength: 60, nullable: false),
                    IsLoanOwedToYou = table.Column<bool>(nullable: false),
                    IsLoanPayed = table.Column<bool>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LoanStartDate = table.Column<DateTime>(nullable: false),
                    LoanEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParameterId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParameterName = table.Column<string>(maxLength: 60, nullable: false),
                    ParameterAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ParameterBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "SavingsParameters",
                columns: table => new
                {
                    SavingsParameterId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SavingsParameterName = table.Column<string>(maxLength: 60, nullable: false),
                    SavingsParameterBalance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsParameters", x => x.SavingsParameterId);
                });

            migrationBuilder.CreateTable(
                name: "LoanPayment",
                columns: table => new
                {
                    LoanPaymentId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LoanId = table.Column<long>(nullable: false),
                    LoanPaymentAmount = table.Column<float>(nullable: false),
                    LoanPaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPayment", x => x.LoanPaymentId);
                    table.ForeignKey(
                        name: "FK_LoanPayment_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExpenseDetails = table.Column<string>(maxLength: 60, nullable: false),
                    IsSavingsParameter = table.Column<bool>(nullable: false),
                    SavingsParameterId = table.Column<long>(nullable: true),
                    ParameterId = table.Column<long>(nullable: true),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    ExpenseTime = table.Column<DateTime>(nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_SavingsParameters_SavingsParameterId",
                        column: x => x.SavingsParameterId,
                        principalTable: "SavingsParameters",
                        principalColumn: "SavingsParameterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterEntry",
                columns: table => new
                {
                    EntryId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParameterId = table.Column<long>(nullable: true),
                    SavingsParameterId = table.Column<long>(nullable: true),
                    IsSavingsParameter = table.Column<bool>(nullable: false),
                    DepositId = table.Column<long>(nullable: false),
                    AddedBalance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterEntry", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_ParameterEntry_Deposit_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposit",
                        principalColumn: "DepositId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterEntry_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParameterEntry_SavingsParameters_SavingsParameterId",
                        column: x => x.SavingsParameterId,
                        principalTable: "SavingsParameters",
                        principalColumn: "SavingsParameterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "ParameterId", "ParameterAmount", "ParameterBalance", "ParameterName" },
                values: new object[,]
                {
                    { 1L, 2000m, 0m, "Groceries" },
                    { 2L, 1000m, 0m, "Medical Expenses" },
                    { 3L, 800m, 0m, "Travel Expenses" },
                    { 4L, 2000m, 0m, "Utilities - Electricity" },
                    { 5L, 500m, 0m, "Movie" },
                    { 6L, 1000m, 0m, "Miscelleneous" }
                });

            migrationBuilder.InsertData(
                table: "SavingsParameters",
                columns: new[] { "SavingsParameterId", "SavingsParameterBalance", "SavingsParameterName" },
                values: new object[,]
                {
                    { 1L, 0f, "Main Savings" },
                    { 2L, 0f, "Shopping" },
                    { 3L, 0f, "Loan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ParameterId",
                table: "Expense",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_SavingsParameterId",
                table: "Expense",
                column: "SavingsParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayment_LoanId",
                table: "LoanPayment",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterEntry_DepositId",
                table: "ParameterEntry",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterEntry_ParameterId",
                table: "ParameterEntry",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterEntry_SavingsParameterId",
                table: "ParameterEntry",
                column: "SavingsParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "LoanPayment");

            migrationBuilder.DropTable(
                name: "ParameterEntry");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "SavingsParameters");
        }
    }
}
