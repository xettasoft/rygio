using Newtonsoft.Json;
using rygio.Helper.ExternalDto;
using System;
using System.IO;
using System.Net;
using System.Text;

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

        public static void post(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType =   "application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Got response
                    length = response.ContentLength;
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
        }
    }
}
