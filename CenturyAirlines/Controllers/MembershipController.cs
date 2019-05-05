using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CenturyAirlines.Models;

namespace CenturyAirlines.Controllers
{
    public class MembershipController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpGet]
        [ActionName("MemberLogin")]
        public ActionResult Index()
        {
            return PartialView("_LoginForm", new LoginModel());
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpPost]
        [ActionName("MemberLogin")]
        public ActionResult Validate(LoginModel model)
        {
            if (Membership.ValidateUser(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);

                //redirect user to appropriate landing page based on role

                if (Roles.IsUserInRole(model.Login, "Admin"))
                {
                    return Redirect("/flights/");
                }
                else
                {
                    return Redirect("/memberbookings/");
                }
            }

            TempData["Status"] = "Invalid Log-in Credentials";
            return RedirectToCurrentUmbracoPage();
        }
    }
}