namespace SoftGamesShop.Data.Models
{

    using SoftGamesShop.Data.Common.Models;

    public class ChatMessage : BaseDeletableModel<int>
    {
        public string User { get; set; }

        public string Text { get; set; }
    }
}
