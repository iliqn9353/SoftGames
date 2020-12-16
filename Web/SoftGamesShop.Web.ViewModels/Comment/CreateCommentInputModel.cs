namespace SoftGamesShop.Web.ViewModels.Comment
{
    public class CreateCommentInputModel
    {
        public int GameId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
