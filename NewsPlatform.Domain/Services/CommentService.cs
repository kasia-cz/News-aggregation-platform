using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly NewsPlatformDbContext _context;
        private readonly IUserService _userService;

        public CommentService(NewsPlatformDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<List<Comment>> AddComment(Comment comment)
        {
            comment.PublishTime = DateTime.Now;
            comment.UserId = _userService.GetCurrentUserId();
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return await _context.Comments.Where(c => c.NewsId == comment.NewsId).ToListAsync();
        }

        public async Task<List<Comment>> DeleteComment(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return await _context.Comments.Where(c => c.NewsId == comment.NewsId).ToListAsync();
        }

        public async Task<List<Comment>> GetNewsComments(Guid newsId)
        {
            return await _context.Comments.Where(c => c.NewsId == newsId).ToListAsync();
        }
    }
}
