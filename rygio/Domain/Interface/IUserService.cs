using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using System.Threading.Tasks;

namespace rygio.Domain.Interface
{
    public interface IUserService : IService<User>
    {
        Task<RefreshTokenResponse> RefreshToken(string refreshtoken);
        Task<string> RevokeRefreshToken(string refreshtoken);
        Task<User> Authenticate(string username, string password);
        Task<User> GoogleAuthentication(string accessToken);
        Task<User> FacebookAuthentication(string accessToken);
        Task<bool> Register(User user, string password, string passwordConfirmation);
        Task<bool> GoogleRegister(string accessToken);
        Task<bool> FacebookRegister(string accessToken);
        Task<bool> SendResetPasswordLink(string email);
        Task<bool> SendResetPasswordOtp(string phone);
        Task<bool> ResetPassword(string username, string code, string newPassword);
        Task<bool> SendConfirmEmailLink(string email);
        Task<bool> ConfirmEmail(string email, string code);
        Task<bool> ChangePassword(int userId,string oldPassword,string newPassword);

    }
}
