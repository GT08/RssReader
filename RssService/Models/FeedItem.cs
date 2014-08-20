namespace RssService.Models
{
    public class FeedItem
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Category { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
