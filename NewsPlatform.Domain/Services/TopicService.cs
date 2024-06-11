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
        private readonly IUserService _userService;

        public TopicService(NewsPlatformDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
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

        public async Task<Topic> GetTopicById(Guid id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                throw new BadRequestException("Invalid topic ID");
            }
            return topic;
        }

        public async Task<List<Topic>> GetSubscribedTopics()
        {
            var currentUser = await _userService.GetCurrentUserWithTopics();

            return currentUser.SubscribedTopics;
        }

        public async Task SubscribeTopic(Guid id)
        {
            var topic = await GetTopicById(id);
            var currentUser = await _userService.GetCurrentUserWithTopics();
            currentUser.SubscribedTopics.Add(topic);

            await _context.SaveChangesAsync();
        }

        public async Task UnsubscribeTopic(Guid id)
        {
            var topic = await GetTopicById(id);
            var currentUser = await _userService.GetCurrentUserWithTopics();
            currentUser.SubscribedTopics.Remove(topic);

            await _context.SaveChangesAsync();
        }
    }
}
