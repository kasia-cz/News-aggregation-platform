using Microsoft.AspNetCore.Identity;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;
using NewsPlatform.Domain.Models;

namespace NewsPlatform.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly NewsPlatformDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(NewsPlatformDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            await _userManager.CreateAsync(user, model.Password);
        }

        public async Task Login(LoginModel model)
        {
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
