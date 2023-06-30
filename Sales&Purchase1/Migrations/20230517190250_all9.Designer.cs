﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_Purchase1.Data;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230517190250_all9")]
    partial class all9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserComLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserCompany")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserContact")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Sales_Purchase1.Models.ChartofAcc", b =>
                {
                    b.Property<int>("AccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccId"), 1L, 1);

                    b.Property<int>("AccCode")
                        .HasColumnType("int");

                    b.Property<string>("AccDesc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("AccType")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("AccUser")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("AccYTD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Acclock")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AccId");

                    b.HasIndex("Id");

                    b.ToTable("ChartofAcc");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("ContactAddress1")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactAddress2")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactCity1")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactCity2")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactComName")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactCountry1")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactCountry2")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactDirectDail")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactFax")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactMobile")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactPerson1")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactPerson2")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactUser")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactWeb")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactZipCode1")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactZipCode2")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactId");

                    b.HasIndex("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.ItemList", b =>
                {
                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<int>("ItemQty")
                        .HasColumnType("int");

                    b.Property<string>("ItemUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ItemUser")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("DocId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ItemLists");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Payment", b =>
                {
                    b.Property<int>("PayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PayId"), 1L, 1);

                    b.Property<int?>("DocId")
                        .HasColumnType("int");

                    b.Property<double>("PayAmount")
                        .HasColumnType("float");

                    b.Property<string>("PayCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PayNote")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PayReference")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PayUser")
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("PaycDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PayId");

                    b.HasIndex("DocId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool>("ProductActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<double?>("ProductCost")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ProductPurchasAcc")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ProductPurchaseDesc")
                        .HasColumnType("nvarchar(256)");

                    b.Property<float?>("ProductPurchaseRate")
                        .HasColumnType("real");

                    b.Property<string>("ProductSellAcc")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ProductSellDesc")
                        .HasColumnType("nvarchar(256)");

                    b.Property<double?>("ProductSellPrice")
                        .HasColumnType("float");

                    b.Property<float?>("ProductSellRate")
                        .HasColumnType("real");

                    b.Property<int?>("ProductStock")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ProductUnit")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductUser")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.SalesPurchase", b =>
                {
                    b.Property<int>("DocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocId"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("DocAddress")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DocCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DocContact")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DocCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DocDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DocExpTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("DocOutstanding")
                        .HasColumnType("float");

                    b.Property<string>("DocReference")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DocStatus")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DocTax")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("DocTotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("DocUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TRId")
                        .HasColumnType("int");

                    b.HasKey("DocId");

                    b.HasIndex("ContactId");

                    b.HasIndex("TRId");

                    b.ToTable("SalesPurchases");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.TaxRate", b =>
                {
                    b.Property<int>("TRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TRId"), 1L, 1);

                    b.Property<string>("TRAcc")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TRCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TRCompenats")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TRName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TRPurhaseT")
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("TRRate")
                        .HasColumnType("real");

                    b.Property<string>("TRSalesT")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TRUser")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TRId");

                    b.ToTable("TaxRates");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Transaction", b =>
                {
                    b.Property<int>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TId"), 1L, 1);

                    b.Property<int?>("AccId")
                        .HasColumnType("int");

                    b.Property<double?>("TCredit")
                        .HasColumnType("float");

                    b.Property<DateTime>("TDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TDebit")
                        .HasColumnType("float");

                    b.Property<string>("TDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TUser")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("TId");

                    b.HasIndex("AccId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sales_Purchase1.Models.ChartofAcc", b =>
                {
                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("ChartofAccs")
                        .HasForeignKey("Id");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Contact", b =>
                {
                    b.HasOne("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Contacts")
                        .HasForeignKey("Id");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.ItemList", b =>
                {
                    b.HasOne("Sales_Purchase1.Models.SalesPurchase", "SalesPurchase")
                        .WithMany("ItemLists")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_Purchase1.Models.Product", "Product")
                        .WithMany("ItemLists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesPurchase");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Payment", b =>
                {
                    b.HasOne("Sales_Purchase1.Models.SalesPurchase", "SalesPurchase")
                        .WithMany("Payments")
                        .HasForeignKey("DocId");

                    b.Navigation("SalesPurchase");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.SalesPurchase", b =>
                {
                    b.HasOne("Sales_Purchase1.Models.Contact", "Contact")
                        .WithMany("SalesPurchases")
                        .HasForeignKey("ContactId");

                    b.HasOne("Sales_Purchase1.Models.TaxRate", "TaxRate")
                        .WithMany("SalesPurchases")
                        .HasForeignKey("TRId");

                    b.Navigation("Contact");

                    b.Navigation("TaxRate");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Transaction", b =>
                {
                    b.HasOne("Sales_Purchase1.Models.ChartofAcc", "ChartofAcc")
                        .WithMany("Transactions")
                        .HasForeignKey("AccId");

                    b.Navigation("ChartofAcc");
                });

            modelBuilder.Entity("Sales_Purchase1.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Navigation("ChartofAccs");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.ChartofAcc", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Contact", b =>
                {
                    b.Navigation("SalesPurchases");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.Product", b =>
                {
                    b.Navigation("ItemLists");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.SalesPurchase", b =>
                {
                    b.Navigation("ItemLists");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Sales_Purchase1.Models.TaxRate", b =>
                {
                    b.Navigation("SalesPurchases");
                });
#pragma warning restore 612, 618
        }
    }
}
