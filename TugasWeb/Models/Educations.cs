using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_M_Educations")]
    public  class Educations
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("major",TypeName ="varchar(100)")]
        [MaxLength(100)]
      
        public String Major { get; set; }

        [Column("degree",TypeName ="varchar(10)")]
        [MaxLength(10)]
      
        public String Degree { get; set; }

        [Column("gpa",TypeName ="decimal(3,2)")]
       
        public double Gpa { get; set; }

       
        [Column("university_id")]
       
       
        public int Universitas_id { get; set; }

        public Universities? Universities { get; set; }
        public Profilings? Profiling { get; set; }

    }
}
