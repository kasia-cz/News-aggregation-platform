using NewsPlatform.Application.DTOs.UserDTOs;
using NewsPlatform.Data.Entities;

namespace NewsPlatform.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<List<ReturnUserDTO>> GetAllUsers();
        Task<ReturnUserDTO> GetUserById(string id);
        Task<ReturnUserDTO> GetCurrentUser();
        Task<ReturnUserDTO> SetUserRole(string id, string requestUserRole);
        Task<ReturnUserDTO> SetUserMinPositivityRate(int requestPositivityRate);
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
