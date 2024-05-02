using Microsoft.EntityFrameworkCore;
using NewsPlatform.Application;
using NewsPlatform.Domain;
using NewsPlatform.Data.Context;
using Microsoft.AspNetCore.Identity;
using NewsPlatform.Data.Entities;
using NewsPlatform.WebAPI.Middlewares;

namespace NewsPlatform.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterDomainServices();
            builder.Services.AddDbContext<NewsPlatformDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<NewsPlatformDbContext>().AddDefaultTokenProviders();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}
