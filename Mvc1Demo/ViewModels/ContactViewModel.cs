using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Mvc1Demo.ViewModels
{
    public class ContactViewModel
    {
        [MinLength(3,ErrorMessage = "Skriv in minst tre tecken")]
        [MaxLength(20)]
        [Required]
        public string Namn { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(150)]
        [Required]
        public string Text { get; set; }
    }
}