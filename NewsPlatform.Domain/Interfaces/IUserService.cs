using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Models;

namespace NewsPlatform.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetCurrentUser();
        Task<User> GetCurrentUserWithTopics();
        Task<string> GetUserRole(User user);
        Task<User> SetUserRole(string id, string requestUserRole);
        Task<User> SetUserMinPositivityRate(int requestPositivityRate);
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
        string GetCurrentUserId();
    }
}
