using System;

namespace rygio.Command.v1
{
    public class UserRegisterationDto
    {

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileDeviceToken { get; set; }
        public string WebDeviceToken { get; set; }
    }
}