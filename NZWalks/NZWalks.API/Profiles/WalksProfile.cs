using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTOs.Walk>().
                ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTOs.WalkDifficulty>().
               ReverseMap();
        }


    }
}

