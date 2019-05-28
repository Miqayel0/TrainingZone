using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.Models.Requests;
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
            CreateMap<User, LoginResponse>();
            CreateMap<RegisterRequest, User>()
                .ConstructUsing(u => new User
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ForMember(au => au.Id, opt => opt.Ignore()).IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
