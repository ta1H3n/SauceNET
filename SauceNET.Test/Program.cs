using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SauceNET.Model;
using SauceNET;

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

            Console.ReadLine();
        }

        static async Task ClientTest()
        {
            var client = new SauceNETClient("");
            var sauce = await client.GetSauceAsync("");
        }
    }
}
