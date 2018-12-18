using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<Sauce> GetSauceAsync(string imageUrl)
        {
            var result = await Client.GetStringAsync("https://saucenao.com/search.php?db=999&output_type=2&testmode=1&numres=16&url=http%3A%2F%2Fsaucenao.com%2Fimages%2Fstatic%2Fbanner.gif");

            var sauce = await ParseSauceAsync(result);

            return sauce;
        }

        public async Task<Sauce> ParseSauceAsync(string rawJson)
        {
            Sauce sauce = null;
            await Task.Run(() =>
            {
                var sauceRaw = JsonConvert.DeserializeObject<SauceRaw>(rawJson);
                sauce = ConvertSauce(sauceRaw);
            });

            return sauce;
        }

        public Sauce ConvertSauce(SauceRaw raw)
        {
            var results = ConvertResults(raw);

            Sauce sauce = new Sauce
            {
                Request = new Request
                {
                    AccountType = raw.user.account_type,
                    LongLimit = raw.user.long_limit,
                    LongRemaining = raw.user.long_remaining,
                    MinimumSimilarity = raw.user.minimum_similarity,
                    QueryImage = raw.user.query_image,
                    QueryImageDisplay = raw.user.query_image_display,
                    ResultCount = raw.user.results_returned,
                    ResultsRequested = raw.user.results_requested,
                    SearchDepth = raw.user.search_depth,
                    ShortLimit = raw.user.short_limit,
                    ShortRemaining = raw.user.short_remaining,
                    Status = raw.user.status,
                    UserId = raw.user.user_id
                },

                Results = results
            };

            return sauce;
        }

        public IList<Result> ConvertResults(SauceRaw raw)
        {
            var results = new List<Result>();

            foreach(var x in raw.results)
            {
                var result = new Result
                {
                    DatabaseId = x.header.index_id,
                    Name = x.header.index_name == null ? "" : x.header.index_name,
                    SourceURLs = x.data.ext_urls == null ? null : x.data.ext_urls,
                    Similarity = x.header.similarity == null ? "" : x.header.similarity,
                    ThumbnailURL = x.header.thumbnail == null ? "" : x.header.thumbnail
                };

                results.Add(result);
            }

            return results;
        }
    }
}
