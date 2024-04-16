﻿using NewsPlatform.Application.DTOs.NewsDTOs;

namespace NewsPlatform.Application.Interfaces
{
    public interface INewsAppService
    {
        Task<List<ReturnNewsDTO>> GetAllNews();
        Task<ReturnNewsDTO> GetNewsById(Guid id);
        Task<ReturnNewsDTO> AddNews(AddNewsDTO requestNewsDTO);
        Task<List<ReturnNewsDTO>> DeleteNews(Guid id);
        Task<ReturnNewsDTO> UpdateNews(Guid id, AddNewsDTO requestNewsDTO);
    }
}
