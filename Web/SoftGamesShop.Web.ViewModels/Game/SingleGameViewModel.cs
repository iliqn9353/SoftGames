namespace SoftGamesShop.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Ganss.XSS;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;
    using SoftGamesShop.Web.ViewModels.Comment;

    public class SingleGameViewModel : IMapFrom<Game>,IMapTo<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string GenresName { get; set; }

        public string RatingName { get; set; }

        public string PlatformsType { get; set; }

        public int PlatformId { get; set; }

        public string Trailer { get; set; }

        public int PlayersCount { get; set; }

        public bool CoOp { get; set; }

        public string Developer { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedByEmail { get; set; }

        public string Content { get; set; }

        public int VotesCount { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public IEnumerable<GameCommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, SingleGameViewModel>()
                 .ForMember(x => x.VotesCount, options =>
                 {
                     options.MapFrom(p => p.Votes.Sum(v => (int)v.VoteKind));
                 })
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/Games/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
