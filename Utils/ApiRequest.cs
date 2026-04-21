using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace AspNetMvc5.Utils
{
    public class ApiRequest
    {
        public class HttpMessage
        {
            public string SiteId { get; set; }
            public string SiteName { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string IpAddress { get; set; }
            public string Area { get; set; }
            public string Class { get; set; }
            public string Method { get; set; }
            public NameValueCollection Parameters { get; set; } = new NameValueCollection();
        }
        public class NameValue
        {
            public string name { get; set; }
            public string value { get; set; }
            public string this[string key]
            {
                get
                {
                    if (this.name == key)
                    {
                        return this.value;
                    }
                    return null;
                }
            }
        }
        public class NameValueCollection : List<NameValue>
        {
            public string this[string key]
            {
                get
                {
                    return this.FirstOrDefault(x => x.name == key)?.value;
                }
            }
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> ApiPost(string reqmsg)
        {
            UserTicketData user = UserTicketData.GetCurrentUser();
            Encrypt encrypt = new Encrypt(user.Password);
            reqmsg = encrypt.EncryptData(reqmsg);

            try
            {
                string fullUrl = $"{GetBaseUri()}api/ResponsePost";

                using (var client = CreateClientWithCookie())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );

                    var content = new StringContent(reqmsg, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync(fullUrl, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string EncryptedJson = await response.Content.ReadAsStringAsync();
                            return encrypt.DecryptData(EncryptedJson);
                        }
                        else
                        {
                            string EncryptedJson = await response.Content.ReadAsStringAsync();
                            string emsg = encrypt.DecryptData(EncryptedJson);
                            return AppAcross.ErrorPrefix + $"{(int)response.StatusCode} {response.ReasonPhrase} - {emsg}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return AppAcross.ErrorPrefix + ex.Message;
            }
        }

        public async Task<string> ApiGet(string reqmsg)
        {
            UserTicketData user = UserTicketData.GetCurrentUser();
            Encrypt encrypt = new Encrypt(user.Password);
            reqmsg = encrypt.EncryptData(reqmsg);

            string fullUrl = $"{GetBaseUri()}api/ResponseGet?reqmsg={Uri.EscapeDataString(reqmsg)}";

            try
            {
                using (var client = CreateClientWithCookie())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );

                    using (HttpResponseMessage response = await client.GetAsync(fullUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string EncryptedJson = await response.Content.ReadAsStringAsync();
                            return encrypt.DecryptData(EncryptedJson);
                        }
                        else
                        {
                            string EncryptedJson = await response.Content.ReadAsStringAsync();
                            string emsg = encrypt.DecryptData(EncryptedJson);
                            return AppAcross.ErrorPrefix + $"{(int)response.StatusCode} {response.ReasonPhrase} - {emsg}";
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return AppAcross.ErrorPrefix + $"Network - {ex.Message}";
            }
            catch (Exception ex)
            {
                return AppAcross.ErrorPrefix + ex.Message;
            }
        }

        private string GetBaseUri()
        {
            return HttpContext.Current.Request.Url.Scheme + "://"
                 + HttpContext.Current.Request.Url.Authority + "/";
        }
        private HttpClient CreateClientWithCookie()
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var cookieContainer = new CookieContainer();
            if (authCookie != null)
            {
                cookieContainer.Add(
                    new Uri(GetBaseUri()),
                    new Cookie(authCookie.Name, authCookie.Value)
                );
            }
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer,
                UseCookies = true
            };

            return new HttpClient(handler);
        }

        public HttpMessage CreateHttpMessage(string Area, string Class, string Method, NameValueCollection Parameters = null)
        {
            UserTicketData user = UserTicketData.GetCurrentUser();

            HttpMessage msg = new HttpMessage()
            {
                SiteId = user.SiteId,
                SiteName = user.SiteName,
                UserId = user.UserId,
                UserName = user.UserName,
                IpAddress = user.IpAddress,
                Area = Area,
                Class = Class,
                Method = Method,
                Parameters = Parameters
            };
            return msg;
        }
    }
}