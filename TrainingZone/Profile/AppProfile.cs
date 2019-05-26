using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.Models.Response;

namespace TrainingZone.MapProfile
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Score, ScoreHistory>()
                .ForMember(dest => dest.FirstPlayerName,
                            opt => opt.MapFrom(src => src.FirstPlayer.FirstName))
                    .ForMember(dest => dest.SecondPlayerName,
                            opt => opt.MapFrom(src => src.SecondPlayer.FirstName))
                        .ForMember(dest => dest.Win,
                            opt => opt.MapFrom(src => !Convert.ToBoolean(src.Winner)))
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<User, ScoreResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
