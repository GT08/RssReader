using System.Web.Mvc;

namespace SteamRss.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            try
            {
                var service = new RssService.RssService();
                var feed = service.GetRssFeed("http://www.escapistmagazine.com/rss/news/0.xml", "News");
                return View(feed);
            }
            catch (System.Exception)
            {
                return View(RssService.RssService.EmptyFeed);
            }
        }

        [HttpPost]
        public JsonResult SetReadStatus(int itemId)
        {
            try
            {
                var service = new RssService.RssService();
                service.SetReadStatus(itemId);
                return Json("success");
            }
            catch (System.Exception)
            {
                return Json("fail");
            }
        }
    }
}
