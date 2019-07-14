using AutoMapper;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.Models.Dtos;
using TrainingZone.Models.Requests;
using TrainingZone.Models.Response;

namespace TrainingZone.MapProfile
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Score, ScoreHistoryDto>()
                    .ForMember(dest => dest.SecondPlayerName, opt => opt.MapFrom(src => src.SecondPlayer.FirstName))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
                    .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Winner == 0 ? "Win" : "Lose"))
                            .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<User, ScoreResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<User, LoginResponse>();
            CreateMap<User, UserResponse>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<RegisterRequest, User>()
                .ConstructUsing(u => new User
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ForMember(au => au.Id, opt => opt.Ignore()).IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            CreateMap<CreateGameRequest, Game>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Game, GameResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
           // CreateMap<Point, MoveDto>().ForMember(d => d.Player, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Player"]));
        }
    }
}
