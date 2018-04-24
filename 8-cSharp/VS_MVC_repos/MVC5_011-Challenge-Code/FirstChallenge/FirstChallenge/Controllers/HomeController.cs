using FirstChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // This is where you add the view (right click inside this method --> Add view...)

            // Make a comics variable to the Index can get it for Razer tag use, I think
            var comics = ComicBookManager.GetComicBooks();
            return View(comics);
        }

        // Make an actionresult item, with the name passed in from the HtmlAction to make the url work
        public ActionResult Detail(int id)
        {
            var comics = ComicBookManager.GetComicBooks();
            var comic = comics.FirstOrDefault(p => p.ComicBookId == id);

            return View(comic);
        }

        // After making this method, add a view (right click in code body
        // This makes the new cshtml pages that correspond to each new comic book

    }
}