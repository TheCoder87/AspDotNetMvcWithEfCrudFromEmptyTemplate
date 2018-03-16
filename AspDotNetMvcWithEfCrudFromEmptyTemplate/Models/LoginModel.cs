using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetMvcWithEfCrudFromEmptyTemplate.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}