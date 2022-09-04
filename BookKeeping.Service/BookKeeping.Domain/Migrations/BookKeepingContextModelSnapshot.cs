﻿// <auto-generated />
using BookKeeping.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookKeeping.Domain.Migrations
{
    [DbContext(typeof(BookKeepingContext))]
    partial class BookKeepingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookKeeping.Service.API.Models.MonthlyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonthlyDatas");
                });

            modelBuilder.Entity("BookKeeping.Service.API.Models.MonthlyReconciliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MonthlyDataId")
                        .HasColumnType("int");

                    b.Property<int>("ReconciliationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("MonthlyDataId");

                    b.HasIndex("ReconciliationId");

                    b.ToTable("MonthlyReconciliations");
                });

            modelBuilder.Entity("BookKeeping.Service.API.Models.Reconciliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reconciliations");
                });

            modelBuilder.Entity("BookKeeping.Service.API.Models.MonthlyReconciliation", b =>
                {
                    b.HasOne("BookKeeping.Service.API.Models.MonthlyData", "MonthlyData")
                        .WithMany("MonthlyReconciliations")
                        .HasForeignKey("MonthlyDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookKeeping.Service.API.Models.Reconciliation", "Reconciliation")
                        .WithMany()
                        .HasForeignKey("ReconciliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonthlyData");

                    b.Navigation("Reconciliation");
                });

            modelBuilder.Entity("BookKeeping.Service.API.Models.MonthlyData", b =>
                {
                    b.Navigation("MonthlyReconciliations");
                });
#pragma warning restore 612, 618
        }
    }
}