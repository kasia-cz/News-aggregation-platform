using NewsPlatform.Application.DTOs.UserDTOs;

namespace NewsPlatform.Application.Interfaces
{
    public interface IUserAppService
    {
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
