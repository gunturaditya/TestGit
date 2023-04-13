using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_TR_Profilings")]
    public  class Profilings
    {
        [Column("employee_nik",TypeName ="char(5)")]
        [MaxLength(5)]
        [Key]
        public String Employee_Nik { get; set; }

        [Column("education_id")]
        public int Education_ID { get; set; }

        public Educations? Educations { get; set; }

        public Employees? Employees { get; set; }
    }
}
