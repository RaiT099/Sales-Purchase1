// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sales_Purchase1.Areas.Identity.Data;

namespace Sales_Purchase1.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            [Display(Name = "First Name")]
            public string Firstname { get; set; }

            [Display(Name = "Last Name")]
            public string Lastname { get; set; }

            [Display(Name = "Company Name")]
            public string UserCompany { get; set; }

            [Display(Name = "Address")]
            public string UserAddress { get; set; }

            [Display(Name = "Contact")]
            public string UserContact { get; set; }

            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Brief Biography")]
            public string UserDescription { get; set; }

            [Display(Name = "")]
            public byte[] UserComLogo { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                UserCompany = user.UserCompany,
                UserAddress = user.UserAddress,
                UserContact = user.UserContact,
                PhoneNumber = phoneNumber,
                UserDescription = user.UserDescription,
                UserComLogo = user.UserComLogo
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var userCompany = user.UserCompany;
            var userAddress = user.UserAddress;
            var userContact = user.UserContact;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userDescription = user.UserDescription;

            if(Input.Firstname != firstName)
            {
                user.FirstName = Input.Firstname;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Lastname != lastName)
            {
                user.LastName = Input.Lastname;
                await _userManager.UpdateAsync(user);
            }

            if (Input.UserCompany != userCompany)
            {
                user.UserCompany = Input.UserCompany;
                await _userManager.UpdateAsync(user);
            }

            if (Input.UserAddress != userAddress)
            {
                user.UserAddress = Input.UserAddress;
                await _userManager.UpdateAsync(user);
            }

            if (Input.UserContact != userContact)
            {
                user.UserContact = Input.UserContact;
                await _userManager.UpdateAsync(user);
            }

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.UserDescription != userDescription)
            {
                user.UserDescription = Input.UserDescription;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0) 
            { 
                var file = Request.Form.Files.FirstOrDefault();

                //check file size and extension
                using(var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.UserComLogo = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
