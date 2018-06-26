using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduleUsers.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        //Generate User's first and last name in navigation bar
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = string.Concat(new string[] { user.FirstName, " ", user.LastName });
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
 
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calendar
        public ActionResult Index()
        {
            return View("~/Views/Shared/Calendar/_index.cshtml");
        }

        //Find all actions and send them to as a Json Object
        public ActionResult findAll()
        {
            var events = db.WorkTimeEvents.Where(g => g.End != null).AsEnumerable().Select(e => new {
                id = e.Id,
                title = e.Title,
                description = e.Note,
                start = e.Start.ToString("yyyy-MM-dd" + "T" + "hh:mm"),
                end = e.End.Value.ToString("yyyy-MM-dd" + "T" + "hh:mm"),
                color = "purple"
            }).ToList();


            return Json(events, JsonRequestBehavior.AllowGet);
        }
    }
}