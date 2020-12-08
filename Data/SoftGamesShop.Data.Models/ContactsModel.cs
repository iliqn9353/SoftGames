using SoftGamesShop.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftGamesShop.Data.Models
{
    public class ContactsModel : BaseDeletableModel<int>
    {
        
        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
