using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            DateTime currentTime = DateTime.Now;
            int hour = DateTime.Now.Hour;
            ViewBag.Hour = hour;
            ViewBag.CurrentTime = currentTime;
            //ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            if (hour < 8)
            {
                ViewBag.Greeting = "Good Morning";
            }
            else if (hour < 16 && hour > 8)
            {
                ViewBag.Greeting = "Bonjour";
            }
            else
            {
                ViewBag.Greeting = "Good Evening";
            }

            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) 
        {
            return View("Thanks", guestResponse);
        }


    }
}