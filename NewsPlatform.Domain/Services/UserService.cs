using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Constants;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Exceptions;
using NewsPlatform.Domain.Interfaces;
using NewsPlatform.Domain.Models;
using System.Security.Claims;

namespace NewsPlatform.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly NewsPlatformDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(NewsPlatformDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new BadRequestException("Invalid user ID");
            }
            return user;
        }

        public async Task<User> GetCurrentUser()
        {
            return await GetUserById(GetCurrentUserId());
        }

        public async Task<string> GetUserRole(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();
            if (userRole == null)
            {
                throw new BadRequestException("Invalid user without a role");
            }
            return userRole;
        }

        public async Task<User> SetUserRole(string id, string requestUserRole)
        {
            var user = await GetUserById(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, requestUserRole);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Register(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Registration failed");
            }
            await _userManager.AddToRoleAsync(user, UserConstants.UserRoles.User);
        }

        public async Task Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Login failed");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public string GetCurrentUserId()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                throw new BadRequestException("No user logged in");
            }
            return currentUserId;
        }
    }
}
