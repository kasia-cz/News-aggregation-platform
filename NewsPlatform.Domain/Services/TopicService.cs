using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Exceptions;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Domain.Services
{
    public class TopicService : ITopicService
    {
        private readonly NewsPlatformDbContext _context;

        public TopicService(NewsPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return await _context.Topics.ToListAsync();
        }

        public async Task<List<Topic>> DeleteTopic(Guid id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                throw new BadRequestException("Invalid topic ID");
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return await _context.Topics.ToListAsync();
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            return await _context.Topics.ToListAsync();
        }
    }
}
