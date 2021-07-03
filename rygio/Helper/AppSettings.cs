using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Helper
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int MaxLoginFailedCount { get; set; }
        public int LoginFailedWaitingTime { get; set; }
        public bool EmailConfirmation { get; set; }
        public bool PhoneConfirmation { get; set; }
        public string SendgridKey { get; set; }
        public string DefaultSender { get; set; }
        public int ResetPasswordDuration { get; set; }
        public string SmsSender { get; set; }
        public string TwilionAcctSID { get; set; }
        public string TwilionAuthKey { get; set; }
    }
}
