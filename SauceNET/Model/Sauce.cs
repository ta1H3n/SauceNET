using System.Collections.Generic;

namespace SauceNET.Model
{
    public class Sauce
    {
        public Request Request { get; set; }
        public IList<Result> Results { get; set; }
        public string Message { get; set; }
    }

    public class Request
    {
        public int UserId { get; set; }
        
        public int AccountType { get; set; }
        
        public string ShortLimit { get; set; }
        
        public string LongLimit { get; set; }
        
        public int LongRemaining { get; set; }
        
        public int ShortRemaining { get; set; }
        
        public int Status { get; set; }
        
        public int ResultsRequested { get; set; }
        
        public string SearchDepth { get; set; }
        
        public double MinimumSimilarity { get; set; }
        
        public string QueryImageDisplay { get; set; }
        
        public string QueryImage { get; set; }
        
        public int ResultCount { get; set; }
    }

    public class Result
    {
        public string Similarity { get; set; }
        public string ThumbnailURL { get; set; }
        public int IndexId { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string SourceURL { get; set; }
        public string InnerSource { get; set; }
        public IList<string> ExtUrls { get; set; }
        public IList<ResultProperty> Properties { get; set; }
    }

    public class ResultProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
