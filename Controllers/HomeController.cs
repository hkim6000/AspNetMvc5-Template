using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Security;
using AspNetMvc5.Classes;
using AspNetMvc5.Models;
using AspNetMvc5.Utils;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            
            ApiRequest request = new ApiRequest();
            HttpMessage msgPages = request.CreateHttpMessage("Home", "Home", "GetPages");

            string resultPages = await request.ApiGet(JsonConvert.SerializeObject(msgPages));
            //string postResult = await request.ApiPost("my message posted");

            if (resultPages.ToLower().StartsWith(AppAcross.ErrorPrefix))
            {
                // error process
            }

            List<AppPage> pages = JsonConvert.DeserializeObject<List<AppPage>>(resultPages);

            HomeModel HomeModel = new HomeModel() { AppPages = pages };
            return View(HomeModel);

        }

        public async Task<ActionResult> AddPage(string pageid, string pagename, string pagesort)
        {
            

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(new NameValue() { name = "pageid", value = pageid });
            parameters.Add(new NameValue() { name = "pagename", value = pagename });
            parameters.Add(new NameValue() { name = "pagesort", value = pagesort });

            ApiRequest request = new ApiRequest();
            HttpMessage msgPageInfo = request.CreateHttpMessage("Home", "Home", "AddPage", parameters);

            string resultPagePropertyAddTab = await request.ApiPost(JsonConvert.SerializeObject(msgPageInfo));

            if (resultPagePropertyAddTab.ToLower().StartsWith(AppAcross.ErrorPrefix.ToLower()))
            {
                // error process
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}