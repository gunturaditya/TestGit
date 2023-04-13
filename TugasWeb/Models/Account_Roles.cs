using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_TR_Account_Roles")]
    public  class Account_Roles
    {
        [Key]
        [Column("id",TypeName = "int")]
        public int Id { get; set; }

        [Column("account_nik",TypeName ="char(5)")]
        [MaxLength(5)]
        public String Account_nik { get; set; }

        [Column("role_id")]
        public int Role_id { get; set;}

        public Account? Account { get; set; }
        public Roles? Roles { get; set; }
    }
}
