using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly NewsPlatformDbContext _context;

        public CommentService(NewsPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> AddComment(Comment comment)
        {
            comment.PublishTime = DateTime.Now;
            //comment.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"; // user added manually to database
            // change to current user ID after adding user registration and login
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
