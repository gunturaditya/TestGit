
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_M_Employees")]
    [Index("Email", IsUnique = true)]
    [Index("Phone", IsUnique = true)]
    public  class Employees
    {
        [Key]
        [Column("nik",TypeName ="char(5)")]
        [MaxLength(5)]
        public String Nik { get; set; }
        [Column("first_name",TypeName ="varchar(50)")]
        [MaxLength(50,ErrorMessage ="Max char is 50"),MinLength(5,ErrorMessage ="Min char 5")]
        public String First_name { get; set; }
        
        [Column("last_name", TypeName = "varchar(50)")]
        [MaxLength (50)]
        
        public String? Last_name { get; set; }

        [Column("birthdate",TypeName ="datetime")]
        [Required(ErrorMessage = "birtday Requied")] 
        public DateTime Birthdate { get; set; }

        [Column("gender")]
        [Required]
        [Display(Name = "Gender")]
        public Gender EmployeeGender{ get; set; }

        [Column("hiring_date", TypeName = "datetime")]
      
        public DateTime Hiring_date { get; set;}

       
        [Column("email", TypeName = "varchar(50)")]
        
        public String Email { get; set; }

        [Column("phone_nummber", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [RegularExpression("[6-9]{1}[0-9]{9}",ErrorMessage ="number invalid")]
        [Required(ErrorMessage ="Number need requied")]
      
        public String? Phone { get; set; }
        [Column("Role")]
        public Role Role { get; set; }

        public Profilings? Profiling { get; set; }
        public Account? Account { get; set; }

    }

    public enum Gender
    {
        LAKI,
        PEREMPUAN
    }

    public enum Role
    {
        Admin,User
    }



}
