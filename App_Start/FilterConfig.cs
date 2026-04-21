using System.Web;
using System.Web.Mvc;
using static AspNetMvc5.Utils.AppAcross;

namespace AspNetMvc5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new AjaxAwareAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
