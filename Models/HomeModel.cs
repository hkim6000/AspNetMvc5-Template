using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AspNetMvc5.Models
{
    public class HomeModel
    {
        public List<AppPage> AppPages { get; set; }
    }

    public class AppPage
    {
        public string PAGE_NAME { get; set; }
        public string PAGE_MENU { get; set; }
    }


}