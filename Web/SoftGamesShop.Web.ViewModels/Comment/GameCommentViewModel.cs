﻿namespace SoftGamesShop.Web.ViewModels.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ganss.XSS;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class GameCommentViewModel:IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}