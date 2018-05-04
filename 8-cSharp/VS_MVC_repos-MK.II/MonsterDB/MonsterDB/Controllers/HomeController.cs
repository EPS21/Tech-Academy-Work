using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            MonsterDB.Models.Monster exampleMonster = new Models.Monster();
            exampleMonster.Monster_ID = 1001;
            exampleMonster.Monster_Name = "Popoporing";
            exampleMonster.Monster_HP = 6969;
            exampleMonster.Monster_Race = "Formless";
            exampleMonster.Monster_Property = "Water 2";

            ViewBag.Message = "Your application description page.";

            return View(exampleMonster);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}