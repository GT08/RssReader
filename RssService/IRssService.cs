using RssService.Models;

namespace RssService
{
    public interface IRssService
    {
        Feed GetRssFeed(string feedUrl);
    }
}