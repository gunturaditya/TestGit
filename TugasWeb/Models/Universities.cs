
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models

{
    [Table("TB_M_Universities")]
    public  class Universities
    {
        [Key]
        [Column("id")]
        
        public int Id { get; set; }

        [Column("name",TypeName ="varchar(100)")]
        [MaxLength(100,ErrorMessage ="Max character is 100")]
        [Required(ErrorMessage ="Name requied!!")]
       
        public String Name { get; set; }

        public ICollection<Educations>? Educations { get; set; }
        
    }
}
