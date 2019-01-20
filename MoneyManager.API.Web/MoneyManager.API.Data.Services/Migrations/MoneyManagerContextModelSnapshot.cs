﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager.API.Data.Services.Context;

namespace MoneyManager.API.Data.Services.Migrations
{
    [DbContext(typeof(MoneyManagerContext))]
    partial class MoneyManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyManager.API.Data.Deposit", b =>
                {
                    b.Property<long>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DepositAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DepositDate");

                    b.Property<string>("DepositSource")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("DepositTime");

                    b.HasKey("DepositId");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("MoneyManager.API.Data.Expense", b =>
                {
                    b.Property<long>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ExpenseAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<string>("ExpenseDetails")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("ExpenseTime");

                    b.Property<bool>("IsSavingsParameter");

                    b.Property<long?>("ParameterId");

                    b.Property<long?>("SavingsParameterId");

                    b.HasKey("ExpenseId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("SavingsParameterId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("MoneyManager.API.Data.Loan", b =>
                {
                    b.Property<long>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsLoanOwedToYou");

                    b.Property<bool>("IsLoanPayed");

                    b.Property<decimal>("LoanAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("LoanDetails")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("LoanEndDate");

                    b.Property<string>("LoanPerson")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("LoanStartDate");

                    b.HasKey("LoanId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("MoneyManager.API.Data.LoanPayment", b =>
                {
                    b.Property<long>("LoanPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LoanId");

                    b.Property<float>("LoanPaymentAmount");

                    b.Property<DateTime>("LoanPaymentDate");

                    b.HasKey("LoanPaymentId");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanPayment");
                });

            modelBuilder.Entity("MoneyManager.API.Data.ParameterEntry", b =>
                {
                    b.Property<long>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AddedBalance")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("DepositId");

                    b.Property<bool>("IsSavingsParameter");

                    b.Property<long?>("ParameterId");

                    b.Property<long?>("SavingsParameterId");

                    b.HasKey("EntryId");

                    b.HasIndex("DepositId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("SavingsParameterId");

                    b.ToTable("ParameterEntry");
                });

            modelBuilder.Entity("MoneyManager.API.Data.Parameters", b =>
                {
                    b.Property<long>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ParameterAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ParameterBalance")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ParameterId");

                    b.ToTable("Parameters");

                    b.HasData(
                        new { ParameterId = 1L, ParameterAmount = 2000m, ParameterBalance = 0m, ParameterName = "Groceries" },
                        new { ParameterId = 2L, ParameterAmount = 1000m, ParameterBalance = 0m, ParameterName = "Medical Expenses" },
                        new { ParameterId = 3L, ParameterAmount = 800m, ParameterBalance = 0m, ParameterName = "Travel Expenses" },
                        new { ParameterId = 4L, ParameterAmount = 2000m, ParameterBalance = 0m, ParameterName = "Utilities - Electricity" },
                        new { ParameterId = 5L, ParameterAmount = 500m, ParameterBalance = 0m, ParameterName = "Movie" },
                        new { ParameterId = 6L, ParameterAmount = 1000m, ParameterBalance = 0m, ParameterName = "Miscelleneous" }
                    );
                });

            modelBuilder.Entity("MoneyManager.API.Data.SavingsParameters", b =>
                {
                    b.Property<long>("SavingsParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("SavingsParameterBalance");

                    b.Property<string>("SavingsParameterName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("SavingsParameterId");

                    b.ToTable("SavingsParameters");

                    b.HasData(
                        new { SavingsParameterId = 1L, SavingsParameterBalance = 0f, SavingsParameterName = "Main Savings" },
                        new { SavingsParameterId = 2L, SavingsParameterBalance = 0f, SavingsParameterName = "Shopping" },
                        new { SavingsParameterId = 3L, SavingsParameterBalance = 0f, SavingsParameterName = "Loan" }
                    );
                });

            modelBuilder.Entity("MoneyManager.API.Data.Expense", b =>
                {
                    b.HasOne("MoneyManager.API.Data.Parameters", "Parameters")
                        .WithMany()
                        .HasForeignKey("ParameterId");

                    b.HasOne("MoneyManager.API.Data.SavingsParameters", "SavingsParameters")
                        .WithMany()
                        .HasForeignKey("SavingsParameterId");
                });

            modelBuilder.Entity("MoneyManager.API.Data.LoanPayment", b =>
                {
                    b.HasOne("MoneyManager.API.Data.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyManager.API.Data.ParameterEntry", b =>
                {
                    b.HasOne("MoneyManager.API.Data.Deposit", "deposits")
                        .WithMany()
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoneyManager.API.Data.Parameters", "Parameters")
                        .WithMany()
                        .HasForeignKey("ParameterId");

                    b.HasOne("MoneyManager.API.Data.SavingsParameters", "SavingsParameters")
                        .WithMany()
                        .HasForeignKey("SavingsParameterId");
                });
#pragma warning restore 612, 618
        }
    }
}
