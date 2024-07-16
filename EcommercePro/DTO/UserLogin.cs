using System.ComponentModel.DataAnnotations;

namespace EcommercePro.DTO
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The UserName is Required")]
        public string username { set; get; }

        [Required(ErrorMessage = "The Password is Required")]
        public string password { set; get; }
        
    }
}
