using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AspNetMvc5.Utils;

namespace AspNetMvc5.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            if (Request.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login(string username, string password, bool rememberMe = false)
        {

            // Replace with real DB check
            if (username == "admin" && password == "1234")
            {

                var userData = new UserTicketData
                {
                    Password = "1234",
                    Role = "Admin",
                    SiteId = "Site1000",
                    SiteName = "New York",
                    UserId = "Json",
                    UserName = "Json",
                    IpAddress = System.Web.HttpContext.Current.Request.UserHostAddress
                };
                string userDataJson = JsonConvert.SerializeObject(userData);

                //create fake user &role
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                          // version
                    "Json",                   // username
                    DateTime.Now,               // issue time
                    DateTime.Now.AddMinutes(30),// expiry
                    false,                      // persistent
                    userDataJson                       // userdata
                );

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);
                ///////////////////////////////////////////////////////

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password.";
            return View("Index");
        }


    }
}