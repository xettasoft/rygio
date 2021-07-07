using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Newtonsoft.Json;
using rygio.Helper.ExternalDto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rygio.Helper
{
    public static class ExternalProviders
    {
        // GET JSON Response
        public static ExternalProviderDto GetGoogleAccountDetails(string accesstoken)
        {

          

            throw new NullReferenceException();
        }

        public static ExternalProviderDto GetFacebookAccountDetails(string url,string accesstoken)
        {


            ExternalProviderDto model = new ExternalProviderDto();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url+ accesstoken);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    model = JsonConvert.DeserializeObject<ExternalProviderDto>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // Log errorText
                }
                throw;
            }
            return model;
        }
    }
}
