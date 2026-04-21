using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AspNetMvc5.Utils
{
    public class UserTicketData
    {
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string IpAddress { get; set; }

        public static UserTicketData GetCurrentUser()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return null;

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null || ticket.Expired) return null;

            return JsonConvert.DeserializeObject<UserTicketData>(ticket.UserData);
        }
    }
}