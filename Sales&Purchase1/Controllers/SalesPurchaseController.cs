using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales_Purchase1.Areas.Identity.Data;
using Sales_Purchase1.Data;
using Sales_Purchase1.Models;
using X.PagedList;
using static Sales_Purchase1.Helper;

namespace Sales_Purchase1.Controllers
{
    [Authorize]
    public class SalesPurchaseController : Controller
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SalesPurchaseController(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: SalesPurchase: PO
        public async Task<IActionResult> POIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "PO" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase: QO
        public async Task<IActionResult> QOIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "QO" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase: Bill
        public async Task<IActionResult> BillIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "Bill" || s.DocType == "PR" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm) ||
                                                 c.DocReference.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase: INV
        public async Task<IActionResult> INVIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "INV" || s.DocType == "CN" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm) ||
                                                 c.DocReference.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase: PR
        public async Task<IActionResult> PRIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "PR" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm) ||
                                                 c.DocReference.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase: CN
        public async Task<IActionResult> CNIndex(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.SalesPurchases.Include(s => s.Contact).Include(s => s.TaxRate).Where(s => s.DocType == "CN" && s.DocUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.DocCode.Contains(searchTerm) ||
                                                 c.DocReference.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.DocCode),
                "Draft" => dBContext.Where(c => c.DocStatus.Contains("Draft")),
                "AwaitingPayment" => dBContext.Where(c => c.DocStatus.Contains("Awaiting Payment")),
                "Paid" => dBContext.Where(c => c.DocStatus.Contains("Paid")),
                _ => dBContext.OrderBy(c => c.DocCode),
            };

            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: SalesPurchase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesPurchases == null)
            {
                return NotFound();
            }

            var salesPurchase = await _context.SalesPurchases
                .Include(s => s.Contact)
                .Include(s => s.TaxRate)
                .FirstOrDefaultAsync(m => m.DocId == id);

            var itemlist = await _context.ItemLists.Include(s => s.Product).Where(n => n.DocId == id).ToListAsync(); ;

            if (salesPurchase == null)
            {
                return NotFound();
            }
            var payment = new Payment { 
                PayAmount = (double)salesPurchase.DocTotalPrice,
                PayUser = salesPurchase.DocUser,
                DocId = salesPurchase.DocId,
                PayCode = salesPurchase.DocCode
        };

            ViewData["Payment"] = payment;
            ViewData["ItemList"] = itemlist;

            return View(salesPurchase);
        }

        // POST: SalesPurchase/BillApprove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int? id)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var salesPurchase = await _context.SalesPurchases.FirstOrDefaultAsync(sp => sp.DocId == id);

            if (salesPurchase != null)
            {
                var chartofAcc = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Inventory");
                var chartofAcc1 = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Accounts Payable");
                
                salesPurchase.DocStatus = "Awaiting Payment";

                var itemLists = await _context.ItemLists.Where(il => il.DocId == id).ToListAsync();

                if (salesPurchase.DocType == "Bill")
                {
                    foreach (var itemList in itemLists)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == itemList.ProductId);
                        if (product != null && product.ProductCategory == "Product")
                        {
                            // Update the product using data from the itemList.
                            if (product.ProductStock == null)
                            {
                                product.ProductStock = itemList.ItemQty;
                            }
                            else
                            {
                                product.ProductStock += itemList.ItemQty;
                            }
                        
                            _context.Update(product);
                        }
                    }

                    List<Transaction> transactions = new List<Transaction>
                    {
                        //Debit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = salesPurchase.DocTotalPrice,
                            TCredit = 0,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc.AccId
                        },

                        //Credit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = 0,
                            TCredit = salesPurchase.DocTotalPrice,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc1.AccId
                        },
                    
                    };
                    _context.Transactions.AddRange(transactions);
                }

                if (salesPurchase.DocType == "PR")
                {
                    chartofAcc = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Inventory");
                    chartofAcc1 = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Accounts Payable");
                    
                    foreach (var itemList in itemLists)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == itemList.ProductId);
                        if (product != null && product.ProductCategory == "Product")
                        {
                            // Update the product using data from the itemList.
                            if (product.ProductStock == null)
                            {
                               product.ProductStock = 0;
                               product.ProductStock -= itemList.ItemQty;
                            }
                            else
                            {
                                product.ProductStock -= itemList.ItemQty;
                            }

                            _context.Update(product);
                        }
                    }

                    List<Transaction> transactions = new List<Transaction>
                    {
                        //Debit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = salesPurchase.DocTotalPrice,
                            TCredit = 0,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc1.AccId
                        },

                        //Credit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = 0,
                            TCredit = salesPurchase.DocTotalPrice,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc.AccId
                        },

                    };
                    _context.Transactions.AddRange(transactions);
                }

                if (salesPurchase.DocType == "INV")
                {
                    chartofAcc = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Inventory");
                    chartofAcc1 = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Accounts Receivable");

                    foreach (var itemList in itemLists)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == itemList.ProductId);
                        if (product != null && product.ProductCategory == "Product")
                        {
                            // Update the product using data from the itemList.
                            if (product.ProductStock == null)
                            {
                                product.ProductStock = 0;
                                product.ProductStock -= itemList.ItemQty;
                            }
                            else
                            {
                                product.ProductStock -= itemList.ItemQty;
                            }

                            _context.Update(product);
                        }
                    }

                    List<Transaction> transactions = new List<Transaction>
                    {
                        //Debit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = salesPurchase.DocTotalPrice,
                            TCredit = 0,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc1.AccId
                        },

                        //Credit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = 0,
                            TCredit = salesPurchase.DocTotalPrice,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc.AccId
                        },

                    };
                    _context.Transactions.AddRange(transactions);
                }


                if (salesPurchase.DocType == "CN")
                {
                    chartofAcc = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Inventory");
                    chartofAcc1 = await _context.ChartofAcc.FirstOrDefaultAsync(c => c.AccUser == loginUsername && c.AccName == "Accounts Receivable");

                    foreach (var itemList in itemLists)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == itemList.ProductId);
                        if (product != null && product.ProductCategory == "Product")
                        {
                            // Update the product using data from the itemList.
                            if (product.ProductStock == null)
                            {
                                product.ProductStock = itemList.ItemQty;
                            }
                            else
                            {
                                product.ProductStock += itemList.ItemQty;
                            }

                            _context.Update(product);
                        }
                    }

                    List<Transaction> transactions = new List<Transaction>
                    {
                        //Debit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = salesPurchase.DocTotalPrice,
                            TCredit = 0,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc.AccId
                        },

                        //Credit
                        new Transaction {
                            TDetail = salesPurchase.DocCode,
                            TDate = DateTime.Now,
                            TDebit = 0,
                            TCredit = salesPurchase.DocTotalPrice,
                            TUser = salesPurchase.DocUser,
                            AccId = chartofAcc1.AccId
                        },

                    };
                    _context.Transactions.AddRange(transactions);
                }


                await _context.SaveChangesAsync();
                TempData["success"] = "Approve Success";

                return RedirectToAction("Details", new { id = salesPurchase.DocId });
            }
            TempData["error"] = "Approve Failed";

            return RedirectToAction("Details", new { id = salesPurchase.DocId });
        }

        // POST: SalesPurchase/Payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment([Bind("PayId,PayCode,PaycDate,PayMethod,PayReference,PayNote,PayAmount,PayUser,DocId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                

                var salesPurchase = await _context.SalesPurchases.FirstOrDefaultAsync(sp => sp.DocId == payment.DocId);
                if (salesPurchase != null)
                {
                    salesPurchase.DocOutstanding -= payment.PayAmount;
                    salesPurchase.DocStatus = "Paid";
                    _context.Entry(salesPurchase).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Payment Success";
                return RedirectToAction("Details", new { id = payment.DocId });
            }
            TempData["error"] = "Payment Failed";
            return RedirectToAction("Details", new { id = payment.DocId });
        }

        // GET: SalesPurchase/ViewPayment
        public async Task<IActionResult> ViewPayment(int id)
        {
            var dBContext =  _context.Payments.Where(p => p.DocId == id);
            return View(await dBContext.ToListAsync());
        }

        // GET: SalesPurchase/QOCreate
        public IActionResult QOCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // GET: SalesPurchase/INVCreate
        public IActionResult INVCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // GET: SalesPurchase/CNCreate
        public IActionResult CNCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // GET: SalesPurchase/POCreate
        public IActionResult POCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // GET: SalesPurchase/BillCreate
        public IActionResult BillCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;
            
            
            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // GET: SalesPurchase/PRCreate
        public IActionResult PRCreate()
        {

            var loginUsername = _userManager.GetUserName(this.User);
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;

            return View();
        }

        // POST: SalesPurchase/QOCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QOCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "QO";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Purchase Order added sucessfully";
                return RedirectToAction(nameof(QOIndex));
            }

            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }


        // POST: SalesPurchase/INVCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> INVCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "INV";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Purchase Order added sucessfully";
                return RedirectToAction(nameof(INVIndex));
            }

            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }

        // POST: SalesPurchase/CNCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CNCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "CN";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Purchase Order added sucessfully";
                return RedirectToAction(nameof(CNIndex));
            }

            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Customer")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductSellPrice != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }

        // POST: SalesPurchase/POCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> POCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "PO";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Purchase Order added sucessfully";
                return RedirectToAction(nameof(POIndex));
            }

            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }

        // POST: SalesPurchase/BillCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BillCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "Bill";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Bill added sucessfully";
                return RedirectToAction(nameof(BillIndex));
            }
           
            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }

        // POST: SalesPurchase/PRCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PRCreate([Bind(Prefix = "Item1")] SalesPurchase salesPurchase, [Bind(Prefix = "Item2")] List<ItemList> itemList)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            salesPurchase.DocUser = loginUsername;
            salesPurchase.DocCreateDate = DateTime.Now;
            salesPurchase.DocOutstanding = salesPurchase.DocTotalPrice;
            salesPurchase.DocType = "PR";
            salesPurchase.DocStatus = "Draft";

            if (ModelState.IsValid)
            {
                _context.Add(salesPurchase);
                await _context.SaveChangesAsync();

                int currentSalesPurchaseId = salesPurchase.DocId;
                foreach (var item in itemList)
                {
                    item.DocId = currentSalesPurchaseId;
                    item.ItemUser = loginUsername;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Purchase Return added sucessfully";
                return RedirectToAction(nameof(PRIndex));
            }

            var contacts = _context.Contacts.Where(c => c.ContactUser == loginUsername && c.ContactGroup == "Supplier")
                                .Select(c => new SelectListItem { Value = c.ContactId.ToString(), Text = c.ContactName })
                                .ToList();

            // Add an empty option at the first position.
            contacts.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ContactId"] = contacts;


            var taxRates = _context.TaxRates.Where(c => c.TRUser == loginUsername)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.TRId.ToString(),
                                    Text = c.TRName
                                }).ToList();

            // Prepend an empty option
            taxRates.Insert(0, new SelectListItem { Value = "", Text = "Select an option...", Selected = true });

            ViewData["TRId"] = taxRates;


            var products = _context.Products.Where(c => c.ProductUser == loginUsername && c.ProductActive == true && c.ProductCost != null)
                                .Select(c => new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName })
                                .ToList();

            // Add an empty option at the first position.
            products.Insert(0, new SelectListItem { Value = "", Text = "Select an option..." });

            ViewData["ProductId"] = products;


            var data = _context.ChartofAcc
                    .Where(c => c.AccUser == loginUsername)
                    .ToList();  // Load data into memory

            var groups = data.GroupBy(c => c.AccType).ToList();

            List<SelectListGroup> selectListGroup = groups
                                                     .Select(g => new SelectListGroup { Name = g.Key })
                                                     .ToList();

            List<SelectListItem> selectListItem = data
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.AccName.ToString(),
                                           Text = c.AccName,
                                           Group = selectListGroup.FirstOrDefault(g => g.Name == c.AccType),
                                           Selected = c.AccName == "Inventory" // Set "Inventory" to be selected
                                       })
                                       .ToList();

            ViewData["ItemType"] = selectListItem;
            return View();
        }


        // GET: SalesPurchase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesPurchases == null)
            {
                return NotFound();
            }

            var salesPurchase = await _context.SalesPurchases
                .Include(s => s.Contact)
                .Include(s => s.TaxRate)
                .FirstOrDefaultAsync(m => m.DocId == id);
            var itemlist = await _context.ItemLists.Include(s => s.Product).Where(n => n.DocId == id).ToListAsync(); ;

            if (salesPurchase == null)
            {
                return NotFound();
            }
            ViewData["ItemList"] = itemlist;

            return View(salesPurchase);
        }

        // POST: SalesPurchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesPurchases == null)
            {
                return Problem("Entity set 'DBContext.SalesPurchases'  is null.");
            }
            var salesPurchase = await _context.SalesPurchases.FindAsync(id);
            if (salesPurchase != null)
            {
                _context.SalesPurchases.Remove(salesPurchase);
                TempData["success"] = "Bill deleted sucessfully";
            }
            
            await _context.SaveChangesAsync();

            if(salesPurchase.DocType == "QO")
            {
                return RedirectToAction(nameof(QOIndex));
            }

            if (salesPurchase.DocType == "INV")
            {
                return RedirectToAction(nameof(INVIndex));
            }

            if (salesPurchase.DocType == "CN")
            {
                return RedirectToAction(nameof(CNIndex));
            }

            if (salesPurchase.DocType == "PO")
            {
                return RedirectToAction(nameof(POIndex));
            }

            if (salesPurchase.DocType == "Bill")
            {
                return RedirectToAction(nameof(BillIndex));
            }

            if (salesPurchase.DocType == "PR")
            {
                return RedirectToAction(nameof(PRIndex));
            }

            return RedirectToAction(nameof(BillIndex));
        }

        private bool SalesPurchaseExists(int id)
        {
          return (_context.SalesPurchases?.Any(e => e.DocId == id)).GetValueOrDefault();
        }

        [HttpGet]
        public JsonResult GetItemlist(int productId)
        {
            var product = _context.Products.SingleOrDefault(s => s.ProductId == productId);

            if (product != null)
            {
                var result = new { product.ProductCost, product.ProductUnit, product.ProductSellPrice };
                return Json(result);
            }
            else
            {
                return Json("Error: Product not found.");
            }
        }

        [HttpGet]
        public JsonResult GetContactName(int contactId)
        {
            // Assuming you have a 'Contacts' table in your database
            var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == contactId);

            if (contact != null)
            {
                var result = new { contact.ContactName, contact.ContactAddress1 };
                return Json(result);
            }

            return Json("Error: Contact not found.");
        }

        [HttpGet]
        public JsonResult GetTaxNum(int TRId)
        {
            // Assuming you have a 'Contacts' table in your database
            var tax = _context.TaxRates.FirstOrDefault(c => c.TRId == TRId);

            if (tax == null)
            {
                return Json(new { success = false, message = "Contact not found" });
            }

            return Json(new { success = true, tRRate = tax.TRRate });
        }

        [HttpGet]
        public async Task<IActionResult> BillCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "Bill");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

        [HttpGet]
        public async Task<IActionResult> PRCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "PR");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

        [HttpGet]
        public async Task<IActionResult> POCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "PO");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

        [HttpGet]
        public async Task<IActionResult> QOCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "QO");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

        [HttpGet]
        public async Task<IActionResult> INVCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "INV");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

        [HttpGet]
        public async Task<IActionResult> CNCheckDocCode(string docCode)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            bool doesDocCodeExist = await _context.SalesPurchases.AnyAsync(x => x.DocCode == docCode && x.DocUser == loginUsername && x.DocType == "CN");
            return Json(new { docCodeExists = doesDocCodeExist });
        }

    }
}
