using System.ComponentModel.DataAnnotations;

namespace AspNetMvcSocial.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username field cannot be empty")]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password field cannot be empty")]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
