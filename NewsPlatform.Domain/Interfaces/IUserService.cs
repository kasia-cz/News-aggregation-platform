using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Models;

namespace NewsPlatform.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetCurrentUser();
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
        string GetCurrentUserId();
    }
}
