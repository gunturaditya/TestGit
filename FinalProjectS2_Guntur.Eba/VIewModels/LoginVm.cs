using System.ComponentModel.DataAnnotations;

namespace FinalProjectS2_Guntur.Eba.VIewModels
{
    public class LoginVm
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
