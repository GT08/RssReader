using System.Collections.Generic;

namespace RssService.Models
{
    public class Feed
    {
        public List<FeedItem> Items;
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
