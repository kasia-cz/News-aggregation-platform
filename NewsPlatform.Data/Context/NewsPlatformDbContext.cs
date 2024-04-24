﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Entities;

namespace NewsPlatform.Data.Context
{
    public class NewsPlatformDbContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        public NewsPlatformDbContext(DbContextOptions<NewsPlatformDbContext> options) : base(options) { }
    }
}
