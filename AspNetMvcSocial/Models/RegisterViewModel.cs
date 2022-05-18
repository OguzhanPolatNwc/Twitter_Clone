using System.ComponentModel.DataAnnotations;

namespace AspNetMvcSocial.Data
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username field cannot be empty")]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Password field cannot be empty")]
        [MinLength(3)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat Password field cannot be empty")]
        [MinLength(3)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password must be the same!")]
        public string PasswordRepeat { get; set; }

        
    }
}
