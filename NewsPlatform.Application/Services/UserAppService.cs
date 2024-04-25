using AutoMapper;
using NewsPlatform.Application.DTOs.UserDTOs;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;
using NewsPlatform.Domain.Models;

namespace NewsPlatform.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAppService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<ReturnUserDTO>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return _mapper.Map<List<ReturnUserDTO>>(users);
        }

        public async Task<ReturnUserDTO> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            return _mapper.Map<ReturnUserDTO>(user);
        }

        public async Task<ReturnUserDTO> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();

            return _mapper.Map<ReturnUserDTO>(user);
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var registerModel = _mapper.Map<RegisterModel>(registerDTO);
            await _userService.Register(registerModel);
        }

        public async Task Login(LoginDTO loginDTO)
        {
            var loginModel = _mapper.Map<LoginModel>(loginDTO);
            await _userService.Login(loginModel);
        }

        public async Task Logout()
        {
            await _userService.Logout();
        }
    }
}
