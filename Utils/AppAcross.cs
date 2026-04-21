using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5.Utils
{
    public class AppAcross
    {
        public static string ErrorPrefix = "Error:";
        public static string RemoveErrorPrefix(string message)
        {
            return message.Replace(AppAcross.ErrorPrefix, string.Empty);
        }

        public class AjaxAwareAuthorizeAttribute : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JavaScriptResult { Script = "LogOut();" };
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
    }
}