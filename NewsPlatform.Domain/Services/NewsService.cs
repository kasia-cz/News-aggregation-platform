using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Constants;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Exceptions;
using NewsPlatform.Domain.Interfaces;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NewsPlatform.Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly NewsPlatformDbContext _context;
        private readonly IUserService _userService;

        public NewsService(NewsPlatformDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<News> AddNews(News news)
        {
            news.PublishTime = DateTime.Now;
            news.PositivityRate = 5; // change later when positivity rate algorithm is ready
            news.SourceLink = "null"; // change to nullable
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return news;
        }

        public async Task<List<News>> AggregateNews()
        {
            var rssLink = @"https://www.pcgamesn.com/mainrss.xml"; // temporary

            try
            {
                var reader = XmlReader.Create(rssLink);
                var feed = SyndicationFeed.Load(reader);

                var existedNews = await _context.News.Select(news => news.SourceLink).ToListAsync();

                var newsDictionary = feed.Items.Select(item => new News()
                {
                    Id = Guid.NewGuid(),
                    Title = item.Title.Text,
                    Author = string.Join(", ", item.Authors.Select(author => author.Name)),
                    Description = item.Summary.Text,
                    PublishTime = item.PublishDate.UtcDateTime,
                    SourceLink = item.Links[0].Uri.ToString(),
                    PositivityRate = 5 // change later
                }).Where(news => !existedNews.Contains(news.SourceLink)).ToDictionary(n => n.SourceLink, n => n);

                foreach (var news in newsDictionary)
                {
                    var newsContent = await GetNewsContentByUrl(news.Key);
                    news.Value.Content = newsContent;
                }

                var newsList = newsDictionary.Values.ToList();
                await _context.News.AddRangeAsync(newsList);
                await _context.SaveChangesAsync();

                return newsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<News>> DeleteNews(Guid id)
        {
            var news = await GetNewsById(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return await GetAllNews();
        }

        public async Task<List<News>> GetAllNews()
        {
            int minimumPositivityRate;
            try
            {
                var currentUser = await _userService.GetCurrentUser();
                minimumPositivityRate = currentUser.MinimumPositivityRate;
            }
            catch (BadRequestException) 
            {
                minimumPositivityRate = UserConstants.DefaultMinPositivityRate;
            }

            return await _context.News.Where(n => n.PositivityRate >= minimumPositivityRate).Include(n => n.Comments).ToListAsync();
        }

        public async Task<News> GetNewsById(Guid id)
        {
            var news = await _context.News.Include(n => n.Comments).ThenInclude(n => n.User).FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                throw new BadRequestException("Invalid news ID");
            }
            return news;
        }

        public async Task<News> UpdateNews(Guid id, News requestNews)
        {
            var news = await GetNewsById(id);
            news.Title = requestNews.Title;
            news.Author = requestNews.Author;
            news.Description = requestNews.Description;
            news.Content = requestNews.Content;
            await _context.SaveChangesAsync();

            return news;
        }

        private static async Task<string> GetNewsContentByUrl(string url)
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var newsContent = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'entry-content')]").InnerHtml;

            return newsContent;
        }
    }
}
