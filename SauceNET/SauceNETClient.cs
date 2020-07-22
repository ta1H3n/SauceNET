using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SauceNET.Model;

namespace SauceNET
{
    public class SauceNETClient
    {
        private readonly string ApiKey;
        private static readonly HttpClient Client = new HttpClient();

        public SauceNETClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<Sauce> GetSauceAsync(string imageUrl, string dbIndex = "999", string numRes = "6")
        {
            var values = new Dictionary<string, string>
            {
                {"db", dbIndex },
                {"output_type", "2" },
                {"api_key", ApiKey },
                {"url", imageUrl },
                {"numres", numRes }
            };
            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("https://saucenao.com/search.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            
            var sauce = await SauceNETUtil.ParseSauceAsync(responseString);
            
            return sauce;
        }
    }   
}
