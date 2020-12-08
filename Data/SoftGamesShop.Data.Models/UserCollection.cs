namespace SoftGamesShop.Data.Models
{
    using SoftGamesShop.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserCollection : BaseDeletableModel<int>
    {
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
