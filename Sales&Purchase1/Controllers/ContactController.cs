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
using X.PagedList;

namespace Sales_Purchase1.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactController(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: Contact
        public async Task<IActionResult> Index(string? searchTerm, string sortOrder, int? page, int pageSize = 10)
        {
            var loginUsername = _userManager.GetUserName(this.User);
            var dBContext = _context.Contacts.Include(c => c.ApplicationUser).Where(c => c.ContactUser == loginUsername);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dBContext = dBContext.Where(c => c.ContactName.Contains(searchTerm) ||
                                                 c.ContactDirectDail.Contains(searchTerm) ||
                                                 c.ContactEmail.Contains(searchTerm));
            }

            dBContext = sortOrder switch
            {
                "name_desc" => dBContext.OrderByDescending(c => c.ContactName),
                "name_asc" => dBContext.OrderBy(c => c.ContactName),
                "directdail_asc" => dBContext.OrderBy(c => c.ContactDirectDail),
                "directdail_desc" => dBContext.OrderByDescending(c => c.ContactDirectDail),
                "email_desc" => dBContext.OrderByDescending(c => c.ContactEmail),
                "email_asc" => dBContext.OrderBy(c => c.ContactEmail),
                _ => dBContext.OrderBy(c => c.ContactName),
            };

            //int pageSize = 10; // Default page size
            int pageNumber = (page ?? 1);

            return View(await dBContext.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,ContactCode,ContactName,ContactComName,ContactPhone,ContactMobile,ContactDirectDail,ContactFax,ContactEmail,ContactWeb,ContactGroup,ContactPerson1,ContactAddress1,ContactZipCode1,ContactCity1,ContactCountry1,ContactPerson2,ContactAddress2,ContactZipCode2,ContactCity2,ContactCountry2,ContactUser,Id")] Contact contact)
        {
            contact.Id = _userManager.GetUserId(this.User);
            contact.ContactUser = _userManager.GetUserName(this.User);
            if (ModelState.IsValid)
            {
               
                _context.Add(contact);
                await _context.SaveChangesAsync();
                TempData["success"] = "Contact created sucessfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", contact.Id);
            return View(contact);
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", contact.Id);
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(/*int id,*/ [Bind("ContactId,ContactCode,ContactName,ContactComName,ContactPhone,ContactMobile,ContactDirectDail,ContactFax,ContactEmail,ContactWeb,ContactGroup,ContactPerson1,ContactAddress1,ContactZipCode1,ContactCity1,ContactCountry1,ContactPerson2,ContactAddress2,ContactZipCode2,ContactCity2,ContactCountry2,ContactUser,Id")] Contact contact)
        {
            //if (id != contact.ContactId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Contact updated sucessfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", contact.Id);
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'DBContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Contact deleted sucessfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return (_context.Contacts?.Any(e => e.ContactId == id)).GetValueOrDefault();
        }
    }
}
