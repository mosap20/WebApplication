using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class prof
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string MotDePasse { get; set; }
    }
}
