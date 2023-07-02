using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class ChartofAccController : Controller
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChartofAccController(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: ChartofAcc
        public async Task<IActionResult> Index(string searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.ChartofAcc.Include(c => c.ApplicationUser).Where(c => c.AccUser == loginUsername);
           
            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.AccType.Contains(searchTerm) ||
                                                 c.AccName.Contains(searchTerm) );
            }

            dBContext = sortOrder switch
            {
                "All" => dBContext.OrderBy(c => c.AccCode),
                "Revenue" => dBContext.Where(c => c.AccType.Contains("Revenue")),
                "Expense" => dBContext.Where(c => c.AccType.Contains("Expense") || c.AccType.Contains("Direct Costs")),
                "Asset" => dBContext.Where(c => c.AccType.Contains("Asset") || c.AccType.Contains("Inventory")),
                "Liability" => dBContext.Where(c => c.AccType.Contains("Liability")),
                "Equity" => dBContext.Where(c => c.AccType.Contains("Equity")),
                _ => dBContext.OrderBy(c => c.AccCode),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        public async Task<IActionResult> Transaction(int id, string searchTerm, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.Transactions.Where(t => t.TUser == loginUsername && t.AccId==id);

            if (dBContext != null && dBContext.Any())
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    dBContext = dBContext.Where(c => c.TDetail.Contains(searchTerm));
                }

                int pageNumber = (page ?? 1);

                return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
            }
            else
            {
                TempData["error"] = "No data";
                return RedirectToAction("Index");
            }
        }


        // GET: ChartofAcc/AddEdit
        // GET: ChartofAcc/AddEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddEdit(int id)
        {   
            if(id == 0)
            {

                ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
                return View(new ChartofAcc());
            }
            else
            {

                var chartofAcc = await _context.ChartofAcc.FindAsync(id);
                if (chartofAcc == null)
                {
                    return NotFound();
                }
                ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", chartofAcc.Id);
                return View(chartofAcc);
            }
        }

        

        // POST: ChartofAcc/AddEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("AccId,AccCode,AccName,AccDesc,AccType,AccYTD,Acclock,AccUser,Id")] ChartofAcc chartofAcc)
        {

            chartofAcc.Id = _userManager.GetUserId(this.User);
            chartofAcc.AccUser = _userManager.GetUserName(this.User);
            if (ModelState.IsValid)
            {
                if(chartofAcc.AccId == 0)
                {
                    chartofAcc.AccUser = _userManager.GetUserName(this.User);
                    _context.Add(chartofAcc);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Account added sucessfully";
                }
                else
                {
                    try
                    {
                        _context.Update(chartofAcc);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Account updated sucessfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ChartofAccExists(chartofAcc.AccId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                
                return Json(new {isValid = true, html = Helper.RenderRazorViewToString(this,"_ViewAll", _context.ChartofAcc.ToPagedList())});
            }
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddEdit", chartofAcc) });
        }

        // GET: ChartofAcc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChartofAcc == null)
            {
                return NotFound();
            }

            var chartofAcc = await _context.ChartofAcc
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.AccId == id);
            if (chartofAcc == null)
            {
                return NotFound();
            }

            return View(chartofAcc);
        }

        // POST: ChartofAcc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChartofAcc == null)
            {
                return Problem("Entity set 'DBContext.ChartofAcc'  is null.");
            }
            var chartofAcc = await _context.ChartofAcc.FindAsync(id);
            if (chartofAcc != null)
            {
                _context.ChartofAcc.Remove(chartofAcc);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Account deleted sucessfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ChartofAccExists(int id)
        {
          return (_context.ChartofAcc?.Any(e => e.AccId == id)).GetValueOrDefault();
        }
    }
}
