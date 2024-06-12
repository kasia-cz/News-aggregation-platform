using NewsPlatform.Application.DTOs.NewsDTOs;

namespace NewsPlatform.Application.Interfaces
{
    public interface INewsAppService
    {
        Task<List<ReturnNewsShortDTO>> GetAllNews();
        Task<ReturnNewsDTO> GetNewsById(Guid id);
        Task<ReturnNewsDTO> AddNews(AddNewsDTO requestNewsDTO);
        Task<List<ReturnNewsShortDTO>> DeleteNews(Guid id);
        Task<ReturnNewsDTO> UpdateNews(Guid id, AddNewsDTO requestNewsDTO);

        Task<List<ReturnNewsShortDTO>> AggregateNews();
    }
}
