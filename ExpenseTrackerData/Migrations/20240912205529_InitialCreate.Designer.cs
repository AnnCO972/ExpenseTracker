﻿// <auto-generated />
using System;
using ExpenseTrackerData.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTrackerData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240912205529_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseTrackerData.Models.Address", b =>
                {
                    b.Property<Guid>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.CreditCard", b =>
                {
                    b.Property<Guid>("CreditCardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillingAddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardholderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WalletID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CreditCardID");

                    b.HasIndex("BillingAddressID");

                    b.HasIndex("WalletID");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.Transaction", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreditCardID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReceiptURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WalletID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionID");

                    b.HasIndex("CreditCardID");

                    b.HasIndex("WalletID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.Wallet", b =>
                {
                    b.Property<Guid>("WalletID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WalletID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.CreditCard", b =>
                {
                    b.HasOne("ExpenseTrackerData.Models.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpenseTrackerData.Models.Wallet", "Wallet")
                        .WithMany("CreditCards")
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BillingAddress");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.Transaction", b =>
                {
                    b.HasOne("ExpenseTrackerData.Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTrackerData.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCard");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.User", b =>
                {
                    b.HasOne("ExpenseTrackerData.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.Wallet", b =>
                {
                    b.HasOne("ExpenseTrackerData.Models.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("ExpenseTrackerData.Models.Wallet", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.User", b =>
                {
                    b.Navigation("Wallet")
                        .IsRequired();
                });

            modelBuilder.Entity("ExpenseTrackerData.Models.Wallet", b =>
                {
                    b.Navigation("CreditCards");
                });
#pragma warning restore 612, 618
        }
    }
}
