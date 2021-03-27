using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal PayStart { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal PayEnd { get; set; }

        public PayType PayType { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }


        public IEnumerable<Project> Projects { get; set; }
    }

    public enum PayType
    {
        Hour,
        Year
    }
}
