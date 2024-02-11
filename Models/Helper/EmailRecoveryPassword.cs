
using System.ComponentModel.DataAnnotations;

namespace Web_Music_v3.Models.Helper
{
    public class EmailRecoveryPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
