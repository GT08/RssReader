using System.Collections.Generic;
using System.Linq;
using QDFeedParser;
using RssService.Feeder;
using RssService.Models;
using RssService.Updater;

namespace RssService
{
    public class RssService : IRssService
    {
        public Feed GetRssFeed(string feedUrl)
        {
            var rssFeeder = new RssFeeder(feedUrl);
            var rssItems = rssFeeder.GetRssFeed();
            var result = MapFeed(rssItems);
            return result;
        }

        private Feed MapFeed(IFeed feed)
        {
            return new Feed
            {
                Title = feed.Title,
                Items = MapItems(feed.Items)
            };
        }

        private List<FeedItem> MapItems(IEnumerable<BaseFeedItem> rssItem)
        {
            var feeder = new RssFeeder();
            return (from i in rssItem
                    select new FeedItem
                    {
                        Title = i.Title,
                        Content = i.Content,
                        Id = i.Link.Substring(43, 5),
                        Category = i.Categories.FirstOrDefault() ?? "News",
                        IsRead = feeder.GetIsRead(i.Link.Substring(43, 5))
                    }).ToList();
        }

        public Feed GetRssFeed(string feedUrl, string category)
        {
            var rssFeeder = new RssFeeder(feedUrl);
            var feed = rssFeeder.GetRssFeed();
            var mappedFeed = MapFeed(feed);
            mappedFeed.Items = mappedFeed.Items.Where(i => i.Category == category).ToList();
            return mappedFeed;
        }

        public void SetReadStatus(int id)
        {
            var rssUpdater = new RssUpdater();
            rssUpdater.SetRssReadStatus(id);
        }

        public static Feed EmptyFeed
        {
            get
            {
                return new Feed
                {
                    Description = string.Empty,
                    Title = "Could not load Feed",
                    Items = new List<FeedItem>()
                };
            }
        }
    }
}
