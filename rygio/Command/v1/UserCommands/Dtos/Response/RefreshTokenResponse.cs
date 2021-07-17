using System;

namespace rygio.Command.v1.Dtos.Response
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
