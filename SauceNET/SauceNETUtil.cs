using Newtonsoft.Json;
using SauceNET.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SauceNET
{
    public static class SauceNETUtil
    {
        public static async Task<Sauce> ParseSauceAsync(string rawJson)
        {
            Sauce sauce = null;
            await Task.Run(() =>
            {
                var sauceRaw = JsonConvert.DeserializeObject<SauceRaw>(rawJson);
                sauce = ConvertSauce(sauceRaw);
            });

            return sauce;
        }

        public static Sauce ConvertSauce(SauceRaw raw)
        {
            var results = ConvertResults(raw);

            Sauce sauce = new Sauce
            {
                Request = new Request
                {
                    AccountType = raw.user.account_type,
                    LongLimit = raw.user.long_limit == null ? null : raw.user.long_limit,
                    LongRemaining = raw.user.long_remaining,
                    MinimumSimilarity = raw.user.minimum_similarity,
                    QueryImage = raw.user.query_image == null ? null : raw.user.query_image,
                    QueryImageDisplay = raw.user.query_image_display == null ? null : raw.user.query_image_display,
                    ResultCount = raw.user.results_returned,
                    ResultsRequested = raw.user.results_requested,
                    SearchDepth = raw.user.search_depth == null ? null : raw.user.search_depth,
                    ShortLimit = raw.user.short_limit == null ? null : raw.user.short_limit,
                    ShortRemaining = raw.user.short_remaining,
                    Status = raw.user.status,
                    UserId = raw.user.user_id
                },

                Results = results,

                Message = raw.user.message == null ? "" : raw.user.message
            };

            return sauce;
        }

        public static IList<Result> ConvertResults(SauceRaw raw)
        {
            var results = new List<Result>();

            if (raw.results != null)
            {
                foreach (var x in raw.results)
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
            }

            return results;
        }
    }
}
