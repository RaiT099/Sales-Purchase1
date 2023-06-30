using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Purchase1.Models
{
    public class TaxRate
    {
        [Key]
        public int TRId { get; set; }

        [Display(Name = "Tax Code")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string TRCode { get; set; }

        [Display(Name = "Tax Name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string TRName { get; set; }

        [Display(Name = "Tax Account")]
        [Column(TypeName = "nvarchar(100)")]
        public string? TRAcc { get; set; }

        [Display(Name = "Tax Purchase")]
        [Column(TypeName = "nvarchar(100)")]
        public string? TRPurhaseT { get; set; }

        [Display(Name = "Tax Sales")]
        [Column(TypeName = "nvarchar(100)")]
        public string? TRSalesT { get; set; }

        [Display(Name = "Tax Compenants")]
        [Column(TypeName = "nvarchar(100)")]
        public string? TRCompenats { get; set; }

        [Display(Name = "Tax Rate")]
        [Required(ErrorMessage = "This field only in number")]
        public float TRRate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? TRUser { get; set; }

        //Relationship
        public virtual ICollection<SalesPurchase>? SalesPurchases { get; set; }
    }
}
