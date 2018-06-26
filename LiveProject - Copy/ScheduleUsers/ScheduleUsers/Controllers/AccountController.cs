﻿using System;
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

namespace ScheduleUsers.Controllers
{
    [Authorize]
    public class AccountController : Controller
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

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public AccountController()
        {
        }

        public AccountController(Applicationdbcontext userManager, ApplicationSignInManager signInManager)
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

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<String> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {                
                ViewBag.SubmitValue = "Clock In";
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            
            // Returns different codes whether the login succeeded or not
            switch (result)
            {
                case SignInStatus.Success:
                    return "Success";
                case SignInStatus.LockedOut:
                    return "Lockout";
                case SignInStatus.RequiresVerification:
                    //return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    return "RequiresVerification";
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");                   
                    return "Invalid";
            }
        }
        
        [HttpGet]     
        public ActionResult LoginRoute() //Separation of concerns. Redirects the User/Admin to proper view when logging in.
        {
            return RedirectToAction("Index", "WorkTimeEvent");            
        }
        
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        // Non Async ver
        //public JsonResult VerifyUser(LoginViewModel workTimeEvent, string ButtonType, string returnUrl)

        // Async ver

        // POST: /Account/VerifyUser
        // Verify User to make sure they exist when user clicks Clock In 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> VerifyUser(LoginViewModel workTimeEvent, string ButtonType, string returnUrl)
        {            
            PasswordHasher ph = new PasswordHasher();

            // Checks Db users for email that matches the email user typed in
            ApplicationUser dbUser = db.Users.FirstOrDefault(x => x.Email == workTimeEvent.Email);

            // Grabs user hashed PW from Db and PW user typed in and check is they match
            var result = ph.VerifyHashedPassword(dbUser.PasswordHash, workTimeEvent.Password);
            
            // If Login button is pressed
            if (ButtonType == "Login")
            {                
                var s = await Login(workTimeEvent, returnUrl);
                if (s == "Success")
                {
                    // returns a new Json object that with its MyProperty value in the constructor,
                    // that will ultimately, go to the LoginRoute from the script in Login.cshtml
                    return Json(new ClockInViewModel(dbUser, true, db, "Login"));                    
                }
            }

            // If Yes button was pressed after modal pops up
            if (ButtonType == "Yes")
            {
                WorkTimeEventController work = new WorkTimeEventController();
                var x = work.Create(workTimeEvent);
                //RedirectToAction("Create", "WorkTimeEvent", workTimeEvent);
                return Json(new ClockInViewModel(dbUser, true, db, "Yes"));
            }

            if (ButtonType == "Clockin")
            {
                return Json(new ClockInViewModel(dbUser, true, db));                
            }


            // If email is not in Db or password does not match, returns viewmodel with ValidUser = false
            if (dbUser == null || result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "There was a problem with the password or username, Please try again");
                //return View("~/Views/Account/Login.cshtml");
                return Json(new ClockInViewModel());
            }
            
            // Else return a ClockInViewModel who returns true for valid user
            else return Json(new ClockInViewModel(dbUser, true, db));           

        }

        // GET: /Account/Register
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [Authorize(Roles = "Admin")] //adds authorization so only the admin can register new users.
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
                    //load index of users after user is registered.
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            
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
        public ActionResult EditPost(string Id)
        {
            var userToUpdate = db.Users.Where(x => x.Id == Id).First();
            
            if (TryUpdateModel(userToUpdate, "", new string[] {"FirstName", "LastName", "UserName", "PhoneNumber", "Department", "Position", "Address", "HourlyPayRate", "Email", "HireDate", "Fulltime"}))
            {
                try
                {
                    db.SaveChanges();
                    return View("~/Views/Home/Index.cshtml");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("","Unable to save changes");
                }
            }
            return View(userToUpdate);
        }
       
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        // Message Counter for the header in _Layout.cshtml
        public ActionResult messageCount() // Gets the User ID and gets the number of messages that are unread
        {
            var userID = User.Identity.GetUserId();
            var messageCount = db.Messages.Where(u => u.Recipient.Id == userID).Where(m => m.UnreadMessage == true).Count();

            ViewBag.MessageCount = "Messages | " + messageCount.ToString(); 

            return PartialView("_MessageCount"); // Returns _MessageCount to the partial

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

     

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}