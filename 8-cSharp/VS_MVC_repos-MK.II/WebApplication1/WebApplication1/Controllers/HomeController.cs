using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyPage()
        {
            var monster = new Models.Monster();
            monster.Name = "poring";
            monster.HP = 21;
            monster.Race = "Formless";
            monster.Property = "Water1";

            ViewBag.a = 1;
            ViewBag.b = 2;
            ViewBag.List = new List<int>() { 1, 2, 3 };        


            ViewBag.DynamicVariable = "wow such viewbag";

            ViewBag.Message = "My new page thing";

            return View(monster);
        }
    }
}