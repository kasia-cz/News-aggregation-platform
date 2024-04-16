using AutoMapper;
using NewsPlatform.Application.DTOs.NewsDTOs;
using NewsPlatform.Data.Entities;

namespace NewsPlatform.Application.MappingProfiles
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<AddNewsDTO, News>();
            CreateMap<News, ReturnNewsDTO>();
        }
    }
}
