using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales_Purchase1.Areas.Identity.Data;
using Sales_Purchase1.Models;
using System.Reflection.Emit;

namespace Sales_Purchase1.Data;

public class DBContext : IdentityDbContext<ApplicationUser>
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ItemList>().HasKey(am => new { am.DocId, am.ProductId });

        builder.Entity<ItemList>().HasOne(m => m.Product).WithMany(am => am.ItemLists).HasForeignKey(m => m.ProductId);
        builder.Entity<ItemList>().HasOne(m => m.SalesPurchase).WithMany(am => am.ItemLists).HasForeignKey(m => m.DocId);


        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }





    public DbSet<Contact> Contacts { get; set; }

    public DbSet<ChartofAcc> ChartofAcc { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<SalesPurchase> SalesPurchases { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<ItemList> ItemLists { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<TaxRate> TaxRates { get; set; }

    internal void SeedData(string email, string id)
    {
        if (!ChartofAcc.Any(i => i.AccUser == email))
        {
            ChartofAcc.AddRange(new List<ChartofAcc>()
                    {
                        new ChartofAcc() {
                            AccCode = 200,
                            AccName = "Sales",
                            AccDesc = "Sales income from principal business activities",
                            AccType = "Revenue",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 260,
                            AccName = "Other Revenue",
                            AccDesc = "Other income not from principal business activies",
                            AccType = "Revenue",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 270,
                            AccName = "Interest Income",
                            AccDesc = "Interest income",
                            AccType = "Revenue",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 310,
                            AccName = "Cost of Goods Sold",
                            AccDesc = "Direct costs of producing the goods sold",
                            AccType = "Direct Costs",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 400,
                            AccName = "Advertising",
                            AccDesc = "Advertising or marketing expenses",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 404,
                            AccName = "Bank Fees",
                            AccDesc = "Fees charged by bank for bank account transactions",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 408,
                            AccName = "Cleaning",
                            AccDesc = "Cleaning fees paid to third party",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 412,
                            AccName = "Consulting & Accounting",
                            AccDesc = "Consultant/Contractor fees",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 416,
                            AccName = "Depreciation",
                            AccDesc = "Depreciation of asset's costs over useful life",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 420,
                            AccName = "Entertainment",
                            AccDesc = "Entertainment expenses",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 425,
                            AccName = "Freight & Courier",
                            AccDesc = "Freight & courier costs",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 429,
                            AccName = "General Expenses",
                            AccDesc = "General business expenses",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 433,
                            AccName = "Insurance",
                            AccDesc = "Insurance expenses",
                            AccType = "Expense",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 610,
                            AccName = "Accounts Receivable",
                            AccDesc = "Outstanding invoices issued but cash not yet received",
                            AccType = "Current Asset",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 620,
                            AccName = "Prepayments",
                            AccDesc = "Expenses paid in advance",
                            AccType = "Current Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 630,
                            AccName = "Inventory",
                            AccDesc = "Value of goods for sale",
                            AccType = "Inventory",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 710,
                            AccName = "Office Equipment",
                            AccDesc = "Office equipment",
                            AccType = "Fixed Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 711,
                            AccName = "Less Accumulated Depreciation ",
                            AccDesc = "Total amount of depreciation for office equipment",
                            AccType = "Fixed Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 720,
                            AccName = "Computer Equipment",
                            AccDesc = "Computer equipment",
                            AccType = "Fixed Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 721,
                            AccName = "Less Accumulated Depreciation",
                            AccDesc = "Total amount of depreciation for computer equipment",
                            AccType = "Fixed Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 3010,
                            AccName = "Deferred Input Tax Account",
                            AccDesc = "Deferred Input Tax Account",
                            AccType = "Current Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 3030,
                            AccName = "Sales Tax Deduction Account",
                            AccDesc = "Sales Tax Deduction Account",
                            AccType = "Current Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 3040,
                            AccName = "Digital Service Tax Claimable Account",
                            AccDesc = "Digital Service Tax Claimable Account",
                            AccType = "Current Asset",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 800,
                            AccName = "Accounts Payable",
                            AccDesc = "Outstanding invoices received from suppliers but not yet paid",
                            AccType = "Current Liability",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 801,
                            AccName = "Unpaid Expense Claims",
                            AccDesc = "Outstanding expense claims from employees",
                            AccType = "Current Liability",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 803,
                            AccName = "Wages Payable",
                            AccDesc = "Outstanding employee salary and wages not paid",
                            AccType = "Current Liability",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 820,
                            AccName = "GST - INPUT",
                            AccDesc = "GST owing to or from your tax authority. This account should be used to offset against either the 'refunds from' or 'payments to' your tax authority that will appear on the bank statement. Software has been designed to use only one GST account to track GST on income and expenses, so there is no need to add any new GST accounts to Software.",
                            AccType = "Current Liability",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 825,
                            AccName = "Employee Tax Payable",
                            AccDesc = "The amount of tax that has been deducted from wages or salaries paid to employes and is due to be paid",
                            AccType = "Current Liability",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 826,
                            AccName = "Superannuation Payable",
                            AccDesc = "Statutory contributions related to employee salary that is due to be paid",
                            AccType = "Current Liability",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 830,
                            AccName = "Income Tax Payable",
                            AccDesc = "The amount of income tax that is due to be paid, also resident withholding tax paid on interest received.",
                            AccType = "Current Liability",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 840,
                            AccName = "Historical Adjustment",
                            AccDesc = "For accounting adjustments",
                            AccType = "Current Liability",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 850,
                            AccName = "Suspense",
                            AccDesc = "An account that allows a transaction to be entered, so the accounts can still be worked on in balance and the entry can be dealt with later.",
                            AccType = "Current Liability",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 960,
                            AccName = "Retained Earnings",
                            AccDesc = "Retained Earnings",
                            AccType = "Equity",
                            Acclock = 1,
                            AccUser  = email,
                            Id = id
                        },

                        new ChartofAcc() {
                            AccCode = 970,
                            AccName = "Owner A Share Capital",
                            AccDesc = "Value of shares by shareholder",
                            AccType = "Equity",
                            Acclock = 0,
                            AccUser  = email,
                            Id = id
                        },
                    });

            SaveChanges();
        }

        if (!Contacts.Any(i => i.ContactUser == email))
        {
            Contacts.AddRange(new List<Contact>()
            {
                new Contact()
                {
                    ContactCode = "C001",
                    ContactName = "Micheal",
                    ContactGroup = "Customer",
                    ContactPerson1 = "Mike",
                    ContactAddress1 = "No 123, Jln Putri",
                    ContactZipCode1 = "81000",
                    ContactCity1 = "Kulai",
                    ContactCountry1 = "Malaysia",
                    ContactUser = email,
                    Id = id
                },

                new Contact()
                {
                    ContactCode = "S001",
                    ContactName = "David",
                    ContactGroup = "Supplier",
                    ContactPerson1 = "David",
                    ContactAddress1 = "No111, Jln Kota Samarahan",
                    ContactZipCode1 = "94300",
                    ContactCity1 = "Kota Samarahan",
                    ContactCountry1 = "Malaysia",
                    ContactUser = email,
                    Id = id
                },

            });
            SaveChanges();
        }

        if (!Products.Any(i => i.ProductUser == email))
        {
            Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    ProductCode = "LP-001",
                    ProductName = "Laptop",
                    ProductCategory = "Product",
                    ProductUnit= "pcs",
                    ProductCost = 1500,
                    ProductActive = true,
                    ProductSellPrice = 2000,
                    ProductUser = email,
                },

                new Product()
                {
                    ProductCode = "HP-001",
                    ProductName = "Handphone",
                    ProductCategory = "Product",
                    ProductUnit= "pcs",
                    ProductCost = 1599,
                    ProductActive = true,
                    ProductSellPrice = 2100,
                    ProductUser = email,
                },

            });
            SaveChanges();
        }

        if (!TaxRates.Any(i => i.TRUser == email))
        {
            TaxRates.AddRange(new List<TaxRate>()
            {
                new TaxRate()
                {
                    TRCode = "NOTAX",
                    TRName = "No Tax",
                    TRRate = 0,
                    TRUser = email,
                },

                new TaxRate()
                {
                    TRCode = "SST",
                    TRName = "SST-Malaysia",
                    TRRate = 6,
                    TRUser = email,
                },

            });
            SaveChanges();
        }

    }
}
