using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Models
{
    public class Company
    {
        public Company()
        {
        }

        public Company(int CompanyId)
        {
            this.CompanyId = CompanyId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Title")]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(3000)]
        [DisplayName("Position Details")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(9,0)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
        [DisplayName("Pay Start")]
        public decimal? PayStart { get; set; }

        [Column(TypeName = "decimal(9,0)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
        [DisplayName("Pay End")]
        public decimal? PayEnd { get; set; }

        [DisplayName("Pay Type")]
        public PayType? PayType { get; set; }

        [DisplayName("Date Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM}")]
        public DateTime DateStart { get; set; }

        [DisplayName("Date End")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM}")]
        public DateTime DateEnd { get; set; }

        public bool Display { get; set; }


        public IEnumerable<Project> Projects { get; set; }


        #region NotMapped
        [DisplayName("Date Start")]
        public string DateStartStr {
            get
            {
                if (DateStart == null || DateStart.Year < 1900)
                    return null;
                else
                    return DateStart.ToString("yyyy-MM", DateTimeFormatInfo.InvariantInfo);
            }
        }

        [DisplayName("Date End")]
        public string DateEndStr
        {
            get
            {
                if (DateEnd == null || DateEnd.Year < 1900)
                    return null;
                else
                    return DateEnd.ToString("yyyy-MM", DateTimeFormatInfo.InvariantInfo);
            }
        }
        #endregion
    }

    public enum PayType
    {
        Hour,
        Year,
        NA
    }
}
