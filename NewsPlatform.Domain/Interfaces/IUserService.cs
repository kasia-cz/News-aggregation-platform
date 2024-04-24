using NewsPlatform.Domain.Models;

namespace NewsPlatform.Domain.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
    }
}
