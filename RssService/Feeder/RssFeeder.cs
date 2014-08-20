using System;
using System.Linq;
using DataLayer;
using QDFeedParser;

namespace RssService.Feeder
{
    public class RssFeeder
    {
        private readonly Uri _url;

        public RssFeeder(string feedUrl)
        {
            _url = new Uri(feedUrl);
        }

        public RssFeeder()
        {
            
        }

        public IFeed GetRssFeed()
        {
            try
            {
                var factory = new HttpFeedFactory();
                return factory.CreateFeed(_url);
            }
            catch (MissingFeedException)
            {
                throw new Exception("Could not read feed");
            }
        }

        public bool GetIsRead(string id)
        {
            try
            {
                using (var db = new RssData())
                {
                    var idNumber = Convert.ToInt32(id);
                    var item = db.ReadHistories.SingleOrDefault(rh => rh.Id == idNumber);
                    return item != null;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}