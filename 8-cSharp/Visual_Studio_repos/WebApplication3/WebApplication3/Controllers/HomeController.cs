using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var tags = MyModel.GetTags();

            var x = MyModel.GetMyModels();

            var doujin1 = new MyModel();
            var doujin2 = new MyModel();
            var doujin3 = new MyModel();

            doujin1.DoujinName = "i'll cum in my littler sister and her friends too!";
            doujin1.DoujinGenre = "loli raep";

            doujin2.DoujinName = "beach swimsuit fuck";
            doujin2.DoujinGenre = "ahegao";
            

            ViewBag.asdf = "I love ass";
            ViewBag.zxcv = "And boypussy";
                       
            // Need to pass one of the doujin guys in there to be displayed in index
            return View(x);
        }
    }
}