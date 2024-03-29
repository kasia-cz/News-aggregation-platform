﻿using Microsoft.Extensions.DependencyInjection;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Application.Services;

namespace NewsPlatform.Application
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection collection)
        {
            collection.AddScoped<INewsAppService, NewsAppService>();
            return collection;
        }
    }
}
