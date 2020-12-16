namespace SoftGamesShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using SoftGamesShop.Data.Common.Models;

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
