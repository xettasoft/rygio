using rygio.Domain.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Authenticate(string username, string password);
        Task<User> ExternalAuthentication(string accessToken, int type);
        Task<bool> Register(User user, string password, string passwordConfirmation);
        Task<bool> ExternalRegister(string accessToken, int type);
        Task<bool> SendResetPasswordLink(string email);
        Task<bool> SendResetPasswordOtp(string phone);
        Task<bool> ResetPassword(string username, string code, string newPassword);
        Task<bool> SendConfirmEmailLink(string email);
        Task<bool> ConfirmEmail(string email, string code);
        Task<bool> ChangePassword(int userId,string oldPassword,string newPassword);

    }
}
