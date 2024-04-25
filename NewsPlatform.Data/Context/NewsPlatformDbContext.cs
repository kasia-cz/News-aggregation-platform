using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Constants;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetRoles(modelBuilder);
        }

        private void SetRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Name = UserConstants.UserRoles.Moderator,
                NormalizedName = UserConstants.UserRoles.Moderator.ToUpper(),
                ConcurrencyStamp = "1"
            },
            new IdentityRole()
            {
                Name = UserConstants.UserRoles.AuthorizedUser,
                NormalizedName = UserConstants.UserRoles.AuthorizedUser.ToUpper(),
                ConcurrencyStamp = "2"
            },
            new IdentityRole()
            {
                Name = UserConstants.UserRoles.User,
                NormalizedName = UserConstants.UserRoles.User.ToUpper(),
                ConcurrencyStamp = "3"
            });
        }
    }
}
