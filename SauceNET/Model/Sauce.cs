using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SauceNET.Model
{
    public class Sauce
    {
        [JsonProperty("header")]
        public RequestDetails RequestDetails { get; }

        [JsonProperty("results")]
        public IList<Result> Results { get; }
    }

    public class RequestDetails
    {
        [JsonProperty("user_id")]
        public int UserId { get; }

        [JsonProperty("account_type")]
        public int AccountType { get; }

        [JsonProperty("short_limit")]
        public string ShortLimit { get; }

        [JsonProperty("long_limit")]
        public string LongLimit { get; }

        [JsonProperty("long_remaining")]
        public int LongRemaining { get; }

        [JsonProperty("short_remaining")]
        public int ShortRemaining { get; }

        [JsonProperty("status")]
        public int Status { get; }

        [JsonProperty("results_requested")]
        public int ResultsRequested { get; }

        [JsonProperty("index")]
        public IEnumerable<Database> SearchedDatabases { get; }

        [JsonProperty("search_depth")]
        public string SearchDepth { get; }

        [JsonProperty("minimum_similarity")]
        public double MinimumSimilarity { get; }

        [JsonProperty("query_image_display")]
        public string QueryImageDisplay { get; }

        [JsonProperty("query_image")]
        public string QueryImage { get; }

        [JsonProperty("results_returned")]
        public int ResultsReturned { get; }
    }

    public class Result
    {
        [JsonProperty("header")]
        public ResultHeader Data { get; }

    }

    public class Database
    {
        [JsonProperty("status")]
        public int Status { get; }

        [JsonProperty("parent_id")]
        public int ParentId { get; }

        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("results")]
        public int ResultCount { get; }
    }

    public class ResultHeader
    {
        [JsonProperty("similarity")]
        public string Similarity { get; }

        [JsonProperty("thumbnail")]
        public string ThumbnailURL{ get; }

        [JsonProperty("index_id")]
        public int DatabaseId { get; }

        [JsonProperty("index_name")]
        public string ResultName { get; }
    }

    public class ResultData
    {
        [JsonProperty("ext_urls")]
        public IList<string> ext_urls { get; }
    }
}
