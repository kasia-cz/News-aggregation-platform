﻿using Microsoft.Extensions.DependencyInjection;
using NewsPlatform.Domain.Interfaces;
using NewsPlatform.Domain.Services;

namespace NewsPlatform.Domain
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection collection)
        {
            collection.AddScoped<INewsService, NewsService>();
            return collection;
        }
    }
}
