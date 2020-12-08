namespace SoftGamesShop.Web.ViewModels.Game
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class AllGamesViewModel : IMapFrom<Game>, IMapFrom<UserCollection>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

        public string Developer { get; set; }

        public int PlayersCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, AllGamesViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/Games/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
