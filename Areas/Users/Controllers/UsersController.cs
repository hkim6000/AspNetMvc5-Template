using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5.Areas.Users.Controllers
{
    public class UsersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return PartialView();
        }
    }
}