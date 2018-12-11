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

            modelBuilder.Entity("MoneyManager.API.Data.AmountSplitParameters", b =>
                {
                    b.Property<int>("parameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("parameterAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("parameterBalance")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("parameterName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("parameterId");

                    b.ToTable("AmountSplitParameters");

                    b.HasData(
                        new { parameterId = 1, parameterAmount = 2000m, parameterBalance = 0m, parameterName = "Groceries" },
                        new { parameterId = 2, parameterAmount = 1000m, parameterBalance = 0m, parameterName = "Medical Expenses" },
                        new { parameterId = 3, parameterAmount = 800m, parameterBalance = 0m, parameterName = "Travel Expenses" },
                        new { parameterId = 4, parameterAmount = 2000m, parameterBalance = 0m, parameterName = "Utilities - Electricity" },
                        new { parameterId = 5, parameterAmount = 500m, parameterBalance = 0m, parameterName = "Movie" },
                        new { parameterId = 6, parameterAmount = 1000m, parameterBalance = 0m, parameterName = "Miscelleneous" }
                    );
                });

            modelBuilder.Entity("MoneyManager.API.Data.DepositDetails", b =>
                {
                    b.Property<int>("depositId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("depositAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("depositDate");

                    b.Property<string>("depositSource")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("depositTime");

                    b.HasKey("depositId");

                    b.ToTable("DepositDetails");
                });

            modelBuilder.Entity("MoneyManager.API.Data.ParameterEntry", b =>
                {
                    b.Property<int>("entryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("addedBalance")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("depositId");

                    b.Property<int>("parameterId");

                    b.HasKey("entryId");

                    b.HasIndex("depositId");

                    b.HasIndex("parameterId");

                    b.ToTable("ParameterEntry");
                });

            modelBuilder.Entity("MoneyManager.API.Data.ParameterEntry", b =>
                {
                    b.HasOne("MoneyManager.API.Data.DepositDetails", "depositDetails")
                        .WithMany()
                        .HasForeignKey("depositId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoneyManager.API.Data.AmountSplitParameters", "amountSplitParameters")
                        .WithMany()
                        .HasForeignKey("parameterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
