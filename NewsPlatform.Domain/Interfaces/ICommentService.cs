using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetNewsComments(Guid newsId);
        Task<List<Comment>> AddComment(Comment comment);
        Task<List<Comment>> DeleteComment(Guid id);
    }
}
