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
            await SomeTest();
            await ClientTest();
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
