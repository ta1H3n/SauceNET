using System;
using System.Collections.Generic;
using System.Text;

namespace SauceNET.Model
{
    public class Sauce
    {
        public Request Request { get; set; }
        public IList<Result> Results { get; set; }
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
        public int DatabaseId { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public IList<string> SourceURLs { get; set; }
        public IList<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Valie { get; set; }
    }
}
