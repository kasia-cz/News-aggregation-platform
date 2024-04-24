using AutoMapper;
using NewsPlatform.Application.DTOs.UserDTOs;
using NewsPlatform.Application.Interfaces;
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
