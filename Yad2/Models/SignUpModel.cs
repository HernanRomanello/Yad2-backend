using System.ComponentModel.DataAnnotations;

namespace Yad2.Models
{
    public class SignUpModel
    {
       

        [Required]
        [EmailAddress]
        public string ?Email { get; set; }

        [Required]  
        [Compare("ConfirmPassword")]
        public string ?Password { get; set; }
        public string ?ConfirmPassword { get; set; }
    }
}
       


