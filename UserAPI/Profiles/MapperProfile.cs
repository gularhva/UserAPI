using AutoMapper;
using UserAPI.DTOs;
using UserAPI.Entities;

namespace UserAPI.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<User, UserDTO>();
        }
    }
}
