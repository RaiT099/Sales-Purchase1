using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sales_Purchase1.Models;

namespace Sales_Purchase1.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? LastName { get; set; }

    [PersonalData]
    public string? UserAddress { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? UserContact { get; set; }

    [PersonalData]
    public string? UserDescription { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(256)")]
    public string? UserCompany { get; set;}

    [PersonalData]
    public byte[]? UserComLogo { get; set; }

    // Relationship
    public virtual ICollection<Contact> Contacts  { get; set; }
    public virtual ICollection<ChartofAcc> ChartofAccs { get; set; }
}

