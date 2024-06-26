﻿using AutoMapper;
using NewsPlatform.Application.DTOs.CommentDTOs;
using NewsPlatform.Data.Entities;

namespace NewsPlatform.Application.MappingProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile() 
        {
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, ReturnCommentDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
