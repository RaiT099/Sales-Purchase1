using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Purchase1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Product Code")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string ProductCode { get; set; }

        [Display(Name = "Product Name")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string? ProductCategory { get; set; }

        [Display(Name = "Unit")]
        [Column(TypeName = "nvarchar(100)")]
        public string? ProductUnit { get; set; }

        [Display(Name = "Cost")]
        public double? ProductCost { get; set; }

        [Display(Name = "Purchase Rate")]
        public float? ProductPurchaseRate { get; set; }

        [Display(Name = "Purchase Account")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ProductPurchasAcc { get; set; }

        [Display(Name = "Purchase Description")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ProductPurchaseDesc { get; set; }

        [Display(Name = "Active")]
        public bool ProductActive { get; set; }

        [Display(Name = "Sell Price")]
        public double? ProductSellPrice { get; set; }

        [Display(Name = "Sell Rate")]
        public float? ProductSellRate { get; set; }

        [Display(Name = "Sell Account")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ProductSellAcc { get; set; }

        [Display(Name = "Sell Description")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ProductSellDesc { get; set; }

        [Display(Name = "Stock")]
        public int? ProductStock { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ProductUser { get; set; }


        //Relationship
        public virtual ICollection<ItemList>? ItemLists { get; set; }
    }
}
