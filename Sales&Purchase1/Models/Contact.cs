using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sales_Purchase1.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Sales_Purchase1.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "Contact Code")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage ="This field cannot empty")]
        public string ContactCode { get; set; }

        [Display(Name = "Contact Name")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string ContactName { get; set; }

        [Display(Name = "Company Name")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactComName { get; set; }

        [Display(Name = "Phone")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactPhone { get; set; }

        [Display(Name = "Mobile")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactMobile { get; set; }

        [Display(Name = "Direct Dial")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactDirectDail { get; set; }

        [Display(Name = "Fax")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactFax { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactEmail { get; set; }

        [Display(Name = "Website")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactWeb { get; set; }

        [Display(Name = "Contact Group")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string ContactGroup { get; set; } //enum?

        [Display(Name = "Person")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactPerson1 { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactAddress1 { get; set; }

        [Display(Name = "Zip Code")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactZipCode1 { get; set; }

        [Display(Name = "City")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactCity1 { get; set; }

        [Display(Name = "Country")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactCountry1 { get; set; }

        [Display(Name = "Person")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactPerson2 { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactAddress2 { get; set; }

        [Display(Name = "Zip Code")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactZipCode2 { get; set; }

        [Display(Name = "City")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactCity2 { get; set; }

        [Display(Name = "Country")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ContactCountry2 { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ContactUser { get; set; }

        //Relationship
        public virtual ICollection<SalesPurchase>? SalesPurchases { get; set; }

        //Application User
        [Column(TypeName = "nvarchar(450)")]
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
