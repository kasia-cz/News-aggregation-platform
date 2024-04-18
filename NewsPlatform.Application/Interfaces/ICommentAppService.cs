using NewsPlatform.Application.DTOs.CommentDTOs;

namespace NewsPlatform.Application.Interfaces
{
    public interface ICommentAppService
    {
        Task<List<ReturnCommentDTO>> GetNewsComments(Guid newsId);
        Task<List<ReturnCommentDTO>> AddComment(AddCommentDTO requestCommentDTO);
        Task<List<ReturnCommentDTO>> DeleteComment(Guid id);

    }
}
