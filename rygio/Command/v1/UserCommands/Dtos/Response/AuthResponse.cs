using System;

namespace rygio.Command.v1.Dtos.Response
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public string MobileDeviceToken { get; set; }
        public string WebDeviceToken { get; set; }
        public bool IsActive { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
