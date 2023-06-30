using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Purchase1.Models
{
    public class Transaction
    {
        [Key]
        public int TId { get; set; }


        [Display(Name = "Transaction Date")]
        public DateTime TDate { get; set; }

        [Display(Name = "Detail")]
        public string? TDetail { get; set; }

        [Display(Name = "Debit")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double? TDebit { get; set; }

        [Display(Name = "Credit")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double? TCredit { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? TUser { get; set; }

        //ChartofAcc
        public int? AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual ChartofAcc? ChartofAcc { get; set; }
    }
}
