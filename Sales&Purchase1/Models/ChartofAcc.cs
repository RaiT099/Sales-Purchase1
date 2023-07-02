using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sales_Purchase1.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Sales_Purchase1.Models
{
    public class ChartofAcc
    {
        [Key]
        public int AccId { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "This field cannot empty")]
        public int AccCode { get; set; }


        [Display(Name = "Account Name")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string AccName { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(450)")]
        public string? AccDesc { get; set; }

        [Display(Name = "Type")]
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field cannot empty")]
        public string AccType { get; set; }


        [Display(Name = "YTD")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double? AccYTD { get; set; }

        [Required(ErrorMessage = "This field cannot empty")]
        public int Acclock { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? AccUser { get; set; }

        //Relationship
        public ICollection<Transaction>? Transactions { get; set; }

        //Application User
        [Column(TypeName = "nvarchar(450)")]
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
