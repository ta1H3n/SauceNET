using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SauceNET.Model;
using SauceNET;
using System.Collections.Generic;

namespace SauceNao
{
    class Program
    {
        public static readonly HttpClient client = new HttpClient();


        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            //await SerializerTest();
            await SomeTest();
            await ClientTest();
        }

        static async Task SerializerTest()
        {
            var result = await client.GetStringAsync("https://saucenao.com/search.php?db=999&output_type=2&testmode=1&numres=16&url=http%3A%2F%2Fsaucenao.com%2Fimages%2Fstatic%2Fbanner.gif");
            Console.WriteLine(result);
            Console.WriteLine();

            JObject json = JObject.Parse(result);
            Console.WriteLine(json.Count);

            var Sauce = JsonConvert.DeserializeObject<SauceRaw>(result);
        }

        static async Task SomeTest()
        {
            var values = new Dictionary<string, string>
            {
                {"db", "999" },
                {"output_type", "2" },
                {"api_key", "" },
                {"url", "https://i.imgur.com/WRCuQAG.jpg" }
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://saucenao.com/search.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
        
        static async Task ClientTest()
        {
            //Enter your SauceNao API key. Optional, leave empty otherwise.
            string apiKey = "";

            //Create your SauceNET client
            var client = new SauceNETClient(apiKey);

            //Enter your image url.
            string image = "https://i.imgur.com/WRCuQAG.jpg";

            //Get the sauce
            var sauce = await client.GetSauceAsync(image);

            //Top result source url, if any.
            string source = sauce.Results[0].SourceURL;
        }
    }
}
