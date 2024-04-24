using Microsoft.Extensions.DependencyInjection;
using NewsPlatform.Domain.Interfaces;
using NewsPlatform.Domain.Services;

namespace NewsPlatform.Domain
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection collection)
        {
            collection.AddScoped<INewsService, NewsService>();
            collection.AddScoped<ITopicService, TopicService>();
            collection.AddScoped<ICommentService, CommentService>();
            collection.AddScoped<IUserService, UserService>();

            return collection;
        }
    }
}
