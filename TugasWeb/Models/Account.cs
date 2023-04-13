
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_M_Account")]
    public  class Account
    {
        [Key]
        [Column("employee_nik",TypeName ="char(5)")]
        [MaxLength(5)]
        public String Employee_nik { get; set; }

        [Column("password",TypeName ="varchar(255)")]
        [MaxLength(255)]
        public string Password { get; set; }
       

        public Employees Employee { get; set; }
        public ICollection<Account_Roles> AccountRoles { get; set; }
    }


}
