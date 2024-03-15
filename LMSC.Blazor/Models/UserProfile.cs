using AutoMapper;
using LMSC.Models;

namespace LMSC.Blazor.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, EditUserModel>()
                .ForMember(dest => dest.ConfirmEmail, opt => opt.MapFrom(src => src.Email));
            CreateMap<EditUserModel, User>();
        }
    }
}
