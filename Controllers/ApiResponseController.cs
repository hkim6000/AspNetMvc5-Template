using AspNetMvc5.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Concurrent;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Controllers
{
    [Authorize]
    public class ApiResponseController : ApiController
    {
        private static readonly ConcurrentDictionary<string, Type> _typeCache = new ConcurrentDictionary<string, Type>();

        // can be replaced with IServiceModule
        private async Task<string> GetMethodResult(string reqmsg)
        {
            string result = string.Empty;

            try
            {
                HttpMessage msg = JsonConvert.DeserializeObject<HttpMessage>(reqmsg);
                string areaLower = msg.Area.ToLower();
                string classLower = msg.Class.ToLower();

                Assembly AppAssembly = Assembly.GetExecutingAssembly();

                string cacheKey = $"{areaLower}.{classLower}";
                Type targetType = _typeCache.GetOrAdd(cacheKey, key =>
                {
                    return AppAssembly.GetTypes().FirstOrDefault(t =>
                        t.Name.ToLower() == classLower &&
                        t.FullName.ToLower().EndsWith(areaLower + "." + classLower));
                });

                if (targetType != null)
                {
                    object TypeObj = Activator.CreateInstance(targetType);
                    if (TypeObj != null)
                    {
                        MethodInfo TypeMethod = TypeObj.GetType().GetMethod(msg.Method);
                        if (TypeMethod != null)
                        {
                            dynamic rawResult = TypeMethod.Invoke(TypeObj, new object[] { msg });
                            if (rawResult is Task<string> task)
                            {
                                var awaitedResult = await rawResult;
                                result = awaitedResult?.ToString();
                            }
                            else
                            {
                                result = rawResult?.ToString();
                            }
                        }
                        else
                        {
                            throw new System.Exception("Method not found: " + msg.Method);
                        }
                    }
                    else
                    {
                        throw new System.Exception("Type cannot create instance");
                    }
                }
                else
                {
                    throw new System.Exception("Type not found: " + msg.Area + "." + msg.Class);
                }
            }
            catch (Exception oe)
            {
                result = AppAcross.ErrorPrefix + oe.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("api/ResponseGet")]
        public async Task<HttpResponseMessage> ResponseGet(string reqmsg)
        {
            UserTicketData user = UserTicketData.GetCurrentUser();
            Encrypt encrypt = new Encrypt(user.Password);
            reqmsg = encrypt.DecryptData(reqmsg);

            string json = await GetMethodResult(reqmsg);
            HttpResponseMessage response = null;

            if (json.ToLower().StartsWith(AppAcross.ErrorPrefix.ToLower()))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
            }
            string jsonData = encrypt.EncryptData(json.Replace(AppAcross.ErrorPrefix, string.Empty));
            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/ResponsePost")]
        public async Task<HttpResponseMessage> ResponsePost(HttpRequestMessage request)
        {
            string reqmsg = await request.Content.ReadAsStringAsync();

            UserTicketData user = UserTicketData.GetCurrentUser();
            Encrypt encrypt = new Encrypt(user.Password);
            reqmsg = encrypt.DecryptData(reqmsg);

            string json = await GetMethodResult(reqmsg);
            HttpResponseMessage response = null;

            if (json.ToLower().StartsWith(AppAcross.ErrorPrefix.ToLower()))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
            }
            string jsonData = encrypt.EncryptData(json.Replace(AppAcross.ErrorPrefix, string.Empty));
            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return response;
        }


        [HttpPost]
        [Route("api/ResponsePostNative")]
        public async Task<HttpResponseMessage> ResponsePostNative([FromBody] string reqmsg)
        {
            UserTicketData user = UserTicketData.GetCurrentUser();
            Encrypt encrypt = new Encrypt(user.Password);
            reqmsg = encrypt.DecryptData(reqmsg);

            string json = await GetMethodResult(reqmsg);
            HttpResponseMessage response = null;

            if (json.ToLower().StartsWith(AppAcross.ErrorPrefix.ToLower()))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
            }
            string jsonData = encrypt.EncryptData(json.Replace(AppAcross.ErrorPrefix, string.Empty));
            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return response;
        }

    }
}