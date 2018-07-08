/**
 * Snippet of what I worked on for login and verifying user validation
 */

namespace ScheduleUsers.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {        
	
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
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

        
    }
}