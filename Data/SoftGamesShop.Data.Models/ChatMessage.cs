namespace SoftGamesShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SoftGamesShop.Data.Common.Models;

    public class ChatMessage : BaseDeletableModel<int>
    {
        [Required]
        public string User { get; set; }

        [Required]

        public string Text { get; set; }
    }
}
