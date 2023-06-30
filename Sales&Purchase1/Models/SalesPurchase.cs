using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Purchase1.Models
{
    public class SalesPurchase
    {
        [Key]
        public int DocId { get; set; }

        [Display(Name = "Code")]
        [Column(TypeName = "nvarchar(100)")]
        //[Required(ErrorMessage = "This field cannot empty")]
        public string? DocCode { get; set; }

        [Display(Name = "Contact")]
        [Column(TypeName = "nvarchar(100)")]
        public string? DocContact { get; set; }

        [Display(Name = "Document Type")]
        [Column(TypeName = "nvarchar(100)")]
        public string? DocType { get; set; }

        [Display(Name = "Date")]
        public DateTime DocDate { get; set; }

        [Display(Name = " Delivery Date")]
        public DateTime? DocDeliveryDate { get; set; }

        [Display(Name = "Expire Date")]
        public DateTime? DocExpTime { get; set; }

        [Display(Name = "Reference")]
        [Column(TypeName = "nvarchar(100)")]
        public string? DocReference { get; set; }

        [Display(Name = "Tax")]
        [Column(TypeName = "nvarchar(100)")]
        public string? DocTax { get; set; }

        public DateTime? DocCreateDate { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(256)")]
        public string? DocAddress { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "nvarchar(100)")]
        public string? DocStatus { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double? DocTotalPrice { get; set; }

        [Display(Name = "Outstanding")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double? DocOutstanding { get; set; }


        public string? DocUser { get; set; }

        //Relationship
        public virtual ICollection<ItemList>? ItemLists { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }

        //Contact
        public int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }

        //Tax Rate
        public int TRId { get; set; }
        [ForeignKey("TRId")]
        public virtual TaxRate? TaxRate { get; set; }
    }
}
