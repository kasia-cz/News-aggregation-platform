using AutoMapper;
using NewsPlatform.Application.DTOs.UserDTOs;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Models;

namespace NewsPlatform.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<LoginDTO, LoginModel>();
            CreateMap<RegisterDTO, RegisterModel>();
            CreateMap<User, ReturnUserDTO>();
        }
    }
}
