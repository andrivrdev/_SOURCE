using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class Credential
    {
        
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
