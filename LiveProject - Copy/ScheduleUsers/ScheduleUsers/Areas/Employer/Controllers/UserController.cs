using System;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ScheduleUsers.Models;
using ScheduleUsers.ViewModels;

namespace ScheduleUsers.Areas.Employer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
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

        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private Applicationdbcontext _userManager;


        public UserController()
        {
        }

        public UserController(Applicationdbcontext userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public Applicationdbcontext UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<Applicationdbcontext>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Employer/User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult ViewUserDetails(string id)
        {
            var userId = id;
            var user = db.Users.Where(w => w.Id == userId).First();
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.FirstName, user.LastName, user.Address, user.HireDate.ToShortDateString(), user.Department, user.Position, user.HourlyPayRate, user.Fulltime);
            return PartialView("_ViewUserDetails", userDetails);
        }
        // GET: /Employer/User/Register
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(db.Roles.ToList(), "", "Name");

            return View();
        }

        // POST: /Employer/User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Department = model.Department,
                    Position = model.Position,
                    Address = model.Address,
                    HireDate = model.HireDate,
                    HourlyPayRate = model.HourlyPayRate,
                    Fulltime = model.Fulltime
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var addRole = UserManager.AddToRole(user.Id, model.UserRoles);
                    //load index of users after user is registered.
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            ViewBag.Name = new SelectList(db.Roles.ToList(), "", "Name");

            //switched these for testing purposes.
            ApplicationUser dataUser = new ApplicationUser();
            dataUser = db.Users.Where(x => x.Id == Id).First();
            //this is just pulling the first user from the database. This is a dummy account.
            RegisterViewModel rv = new RegisterViewModel();
            rv.PhoneNumber = dataUser.PhoneNumber;
            rv.FirstName = dataUser.FirstName;
            rv.LastName = dataUser.LastName;
            rv.UserName = dataUser.UserName;
            rv.Department = dataUser.Department;
            rv.Position = dataUser.Position;
            rv.Address = dataUser.Address;
            rv.HourlyPayRate = dataUser.HourlyPayRate;
            rv.HireDate = dataUser.HireDate;
            rv.Email = dataUser.Email;
            if (dataUser == null)
            {
                return HttpNotFound();
            }

            return View("Edit", rv);

        }

        // POST: Update/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditPost(RegisterViewModel rvm)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var userToUpdate = db.Users.Find(rvm.Id);

            var removeRole = UserManager.RemoveFromRole(userToUpdate.Id, userToUpdate.Roles.ToString());

            var addRole = UserManager.AddToRole(userToUpdate.Id, rvm.UserRoles);


            if (ModelState.IsValid)
            {
                userToUpdate = new ApplicationUser
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    PhoneNumber = rvm.PhoneNumber,
                    Department = rvm.Department,
                    Position = rvm.Position,
                    Address = rvm.Address,
                    HireDate = rvm.HireDate,
                    HourlyPayRate = rvm.HourlyPayRate,
                    Fulltime = rvm.Fulltime
                };
            }

            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(userToUpdate);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}