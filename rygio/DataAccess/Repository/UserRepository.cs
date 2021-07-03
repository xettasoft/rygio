using Microsoft.Extensions.Options;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rygio.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmEmail(string email, string code)
        {
            throw new NotImplementedException();
        }

        public Task<User> ExternalAuthentication(string accessToken, int type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExternalRegister(string accessToken, int type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(User user, string password, string passwordConfirmation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string username, string code, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendConfirmEmailLink(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendResetPasswordLink(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendResetPasswordOtp(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
