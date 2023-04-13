using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudy1.Models
{
    [Table("TB_M_Roles")]
    public  class Roles
    {
        [Key]
        [Column("id",TypeName ="int")]
        public int Id { get; set; }

        [Column("name",TypeName ="varchar(50)")]
        [MaxLength(50)]
        [Required] 
        public string Name { get; set; }


        public ICollection<Account_Roles>? Account_Roles { get; set; }


    }
}
