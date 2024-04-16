using AutoMapper;
using NewsPlatform.Application.DTOs.NewsDTOs;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Application.Services
{
    public class NewsAppService : INewsAppService
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public NewsAppService(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        public async Task<ReturnNewsDTO> AddNews(AddNewsDTO requestNewsDTO)
        {
            var requestNews = _mapper.Map<News>(requestNewsDTO);
            var news = await _newsService.AddNews(requestNews);

            return _mapper.Map<ReturnNewsDTO>(news);
        }

        public async Task<List<ReturnNewsDTO>> DeleteNews(Guid id)
        {
            var newsList = await _newsService.DeleteNews(id);

            return _mapper.Map<List<ReturnNewsDTO>>(newsList);
        }

        public async Task<List<ReturnNewsDTO>> GetAllNews()
        {
            var newsList = await _newsService.GetAllNews();

            return _mapper.Map<List<ReturnNewsDTO>>(newsList);
        }

        public async Task<ReturnNewsDTO> GetNewsById(Guid id)
        {
            var news = await _newsService.GetNewsById(id);

            return _mapper.Map<ReturnNewsDTO>(news);
        }

        public async Task<ReturnNewsDTO> UpdateNews(Guid id, AddNewsDTO requestNewsDTO)
        {
            var requestNews = _mapper.Map<News>(requestNewsDTO);
            var news = await _newsService.UpdateNews(id, requestNews);

            return _mapper.Map<ReturnNewsDTO>(news);
        }
    }
}
