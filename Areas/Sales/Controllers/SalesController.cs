using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5.Areas.Sales.Controllers
{
    public class SalesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}