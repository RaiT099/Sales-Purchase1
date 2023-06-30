using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales_Purchase1.Areas.Identity.Data;
using Sales_Purchase1.Data;
using Sales_Purchase1.Models;
using static Sales_Purchase1.Helper;

namespace Sales_Purchase1.Controllers
{
    [Authorize]
    public class TaxRateController : Controller
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaxRateController(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: TaxRate
        public async Task<IActionResult> Index(string searchTerm)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.TaxRates.Where(c => c.TRUser == loginUsername);


            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.TRName.Contains(searchTerm));
            }

            return View(await dBContext.ToListAsync());
            //return _context.TaxRates != null ? 
            //          View(await _context.TaxRates.ToListAsync()) :
            //          Problem("Entity set 'DBContext.TaxRates'  is null.");
        }

        // GET: TaxRate/AddEdit
        // GET: TaxRate/AddEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddEdit(int? id)
        {
            if(id == 0)
            {
                return View(new TaxRate());
            }

            else
            {
                var taxRate = await _context.TaxRates
                                .FirstOrDefaultAsync(m => m.TRId == id);
                            if (taxRate == null)
                            {
                                return NotFound();
                            }

                            return View(taxRate);
            }
        }


        // POST: TaxRate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("TRId,TRCode,TRName,TRAcc,TRPurhaseT,TRSalesT,TRCompenats,TRRate,TRUser")] TaxRate taxRate)
        {
            taxRate.TRUser = _userManager.GetUserName(this.User);
            if (ModelState.IsValid)
            {
                if (taxRate.TRId == 0)
                {
                    _context.Add(taxRate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(taxRate);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TaxRateExists(taxRate.TRId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.TaxRates.ToList()) });

            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddEdit", taxRate) });
        }


        // GET: TaxRate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaxRates == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRates
                .FirstOrDefaultAsync(m => m.TRId == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            return View(taxRate);
        }

        // POST: TaxRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaxRates == null)
            {
                return Problem("Entity set 'DBContext.TaxRates'  is null.");
            }
            var taxRate = await _context.TaxRates.FindAsync(id);
            if (taxRate != null)
            {
                _context.TaxRates.Remove(taxRate);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Tax deleted sucessfully";
            return RedirectToAction(nameof(Index));
        }

        private bool TaxRateExists(int id)
        {
          return (_context.TaxRates?.Any(e => e.TRId == id)).GetValueOrDefault();
        }
    }
}
