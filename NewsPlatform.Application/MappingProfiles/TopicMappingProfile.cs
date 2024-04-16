using AutoMapper;
using NewsPlatform.Application.DTOs.TopicDTOs;
using NewsPlatform.Data.Entities;

namespace NewsPlatform.Application.MappingProfiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<AddTopicDTO, Topic>();
            CreateMap<Topic, ReturnTopicDTO>();
        }
    }
}
