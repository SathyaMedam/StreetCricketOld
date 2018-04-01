using System.Net.Http;
using System.Net.Http.Headers;

namespace StreetCricket.Data
{
     
    public class RestService
    {
       HttpClient client;

        public RestService()
        {
            client = new HttpClient {MaxResponseContentBufferSize = 256000};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded'"));
        }

      
    }
}
