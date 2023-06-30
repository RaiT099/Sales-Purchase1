using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Purchase1.Models
{
    public class Payment
    {
        [Key]
        public int PayId { get; set; }

        [Display(Name = "Paid Code")]
        [Column(TypeName = "nvarchar(256)")]
        //[Required(ErrorMessage = "This field cannot empty")]
        public string PayCode { get; set; }

        [Display(Name = "Date Paid")]
        public DateTime PaycDate { get; set; }

        [Display(Name = "Paid Method")]
        [Column(TypeName = "nvarchar(256)")]
        public string PayMethod { get; set; }

        [Display(Name = "Reference")]
        [Column(TypeName = "nvarchar(256)")]
        public string? PayReference { get; set; }

        [Display(Name = "Note")]
        [Column(TypeName = "nvarchar(256)")]
        public string? PayNote { get; set; }

        [Display(Name = "Amount Paid")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double PayAmount { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? PayUser { get; set; }



        public int? DocId { get; set; }
        [ForeignKey("DocId")]
        public virtual SalesPurchase? SalesPurchase { get; set; }
    }
}
