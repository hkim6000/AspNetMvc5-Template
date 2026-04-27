using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AspNetMvc5.App_Start;
using AspNetMvc5.Utils;

namespace AspNetMvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //gateway level permission will be here
            //if (request.Url.AbsolutePath.ToLower().Contains("/admin/") && !user.Role.Contains("Admin"))
            //{
            //    Response.StatusCode = 403;
            //    Response.End();
            //}

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return;

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null || ticket.Expired) return;

            UserTicketData userData = JsonConvert.DeserializeObject<UserTicketData>(ticket.UserData);
            string[] roles = userData.Role.Split(',');
            var identity = new FormsIdentity(ticket);
            var principal = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;
        }

    }
}
