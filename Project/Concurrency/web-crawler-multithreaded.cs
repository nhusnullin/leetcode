using System.Collections.Generic;

namespace Project.Concurrency
{
    public class Web_crawler_multithreaded
    {
        
        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {

            return null;

        }
        
    }
    
    
    public class HtmlParser {
        // Return a list of all urls from a webpage of given url.
        // This is a blocking call, that means it will do HTTP request and return when this request is finished.
        public List<string> getUrls(string url)
        {
            return new List<string>();
        }
    }
}