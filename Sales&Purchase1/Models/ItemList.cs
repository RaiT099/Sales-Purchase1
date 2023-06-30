using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Sales_Purchase1.Models
{
    public class ItemList
    {
        public int DocId { get; set; }
        public virtual SalesPurchase? SalesPurchase { get; set; }

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [Display(Name = "Item")]
        public int? ItemId { get; set; }

        [Display(Name = "Qty")]
        public int ItemQty { get; set; }

        [Display(Name = "Unit")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ItemUnit { get; set; }

        [Display(Name = "Acount Type")]
        [Column(TypeName = "nvarchar(256)")]
        public string? ItemType { get; set; }

        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Double ItemPrice { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? ItemUser { get; set; }
    }
}
