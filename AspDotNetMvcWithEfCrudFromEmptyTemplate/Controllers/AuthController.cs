using AspDotNetMvcWithEfCrudFromEmptyTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMvcWithEfCrudFromEmptyTemplate.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)    // Checks if the input fields have correct format
            {
                return View(model); // returns the view with user input values so that  user does not have to retype again
            }

            if (model.EmailId == "admin@admin.com" && model.Password == "Password@123")
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "Password@123"),
                    new Claim(ClaimTypes.Country, "India")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            return View(model);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

    }
}