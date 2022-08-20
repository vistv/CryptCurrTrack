using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace CryptCurrTrack
{
    public static class HttpInfor
    {
        public static readonly HttpClient client = new HttpClient();
        public static string responseBody;


        public static async Task GetHttpData(string request_str)
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(request_str);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();


                //info = json.user.id;
            }
            catch (HttpRequestException e)
            {
                responseBody = "Exception Caught!" + " Message : " + e.Message;

            }
        }
    }
}


