using System;
using System.Linq;
using DataLayer;

namespace RssService.Updater
{
    public class RssUpdater
    {
        public void SetRssReadStatus(int id)
        {
            using (var db = new RssData())
            {
                var readHistory = db.ReadHistories.SingleOrDefault(rh => rh.Id == id);
                if (readHistory == null)
                {
                    db.ReadHistories.Add(new ReadHistory {Id = id, ReadDate = DateTime.Now});
                }
                else
                {
                    db.ReadHistories.Remove(readHistory);
                }

                db.SaveChanges();
            }
        }
    }
}