﻿namespace NewsPlatform.Application.DTOs.UserDTOs
{
    public class ReturnUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int MinimumPositivityRate { get; set; }
    }
}
