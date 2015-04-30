using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using CMS.Core.DependencyResolution;
using CMS.Core.UI.ViewModels.Models;

namespace CMS.Core.UI.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult SignIn()
        {
            return View(new SignInView());
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult SignIn(SignInView signInView)
        {
            if (!ModelState.IsValid)
                return View("SignIn", signInView);
            var authenticationService = DI.GetAuthenticationService();
            if (authenticationService.PasswordMatches(signInView.UserName, signInView.Password))
            {
                FormsAuthentication.SetAuthCookie(signInView.UserName, true);

                return Redirect(FormsAuthentication.GetRedirectUrl(signInView.UserName, true));
                //return Redirect("https://apps.ccisd.net/Fees/");
            }
            ModelState.AddModelError("SignIn", "Please enter valid Username/Password.");
            return View("SignIn");
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
            //return Redirect("https://apps.ccisd.net/Fees/Authentication/SignIn");
        }
    }
}
