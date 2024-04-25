using NewsPlatform.Application.DTOs.UserDTOs;

namespace NewsPlatform.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<List<ReturnUserDTO>> GetAllUsers();
        Task<ReturnUserDTO> GetUserById(string id);
        Task<ReturnUserDTO> GetCurrentUser();
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
