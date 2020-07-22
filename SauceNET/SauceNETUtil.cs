using Newtonsoft.Json;
using SauceNET.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
                sauce = ParseSauce(sauceRaw);
            });

            return sauce;
        }

        public static Sauce ParseSauce(SauceRaw raw)
        {
            var results = ParseResults(raw);
            results = results.OrderByDescending(x => x.Similarity).ToList();

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

        public static IList<Result> ParseResults(SauceRaw raw)
        {
            var results = new List<Result>();

            if (raw.results != null)
            {
                foreach (var x in raw.results)
                {
                    Int32.TryParse(x.header.index_name.Split('#', ':')[1], out int index);
                    string dbName;

                    try
                    {
                        dbName = Databases.DatabaseNames[index];
                    } catch (KeyNotFoundException)
                    {
                        dbName = "Unknown";
                    }

                    var result = new Result
                    {
                        IndexId = x.header.index_id,
                        Name = x.header.index_name == null ? "" : x.header.index_name,
                        SourceURL = x.data.ext_urls == null ? null : x.data.ext_urls[0],
                        Similarity = x.header.similarity == null ? "" : x.header.similarity,
                        ThumbnailURL = x.header.thumbnail == null ? "" : x.header.thumbnail,
                        DatabaseName = dbName,
                        InnerSource = x.data.Source,
                        ExtUrls = x.data.ext_urls,

                        Properties = ParseProperties(x.data)
                    };

                    results.Add(result);
                }
            }

            return results;
        }

        public static IList<ResultProperty> ParseProperties(Data raw)
        {
            var properties = new List<ResultProperty>();

            foreach (var prop in raw.GetType().GetProperties())
            {
                try
                {
                    if(prop.PropertyType == typeof(string) || prop.PropertyType == typeof(int?) || prop.PropertyType == typeof(int))
                    properties.Add(new ResultProperty { Name = prop.Name, Value = prop.GetValue(raw).ToString() });
                }
                catch { };
            }

            return properties;
        }
    }
}
