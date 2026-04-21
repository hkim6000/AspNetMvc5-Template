using AspNetMvc5.Models;
using AspNetMvc5.Utils;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Classes.Home
{
    public class Home
    {
        public async Task<string> GetPages(HttpMessage msg)
        {
            OraData ora = new OraData();
            string emsg = string.Empty;
            DataTable dt = null;

            string sSql = @" select page_name,page_menu from xyspage";
            (dt, emsg) = await ora.GetData(sSql);
            if (emsg != string.Empty)
            {
                return "Error: " + emsg;
            }
            else
            {
                if (dt != null)
                {
                    string json = JsonConvert.SerializeObject(dt);
                    List<AppPage> pages = JsonConvert.DeserializeObject<List<AppPage>>(json);

                    string result = JsonConvert.SerializeObject(pages);
                    return result;
                }
                else
                {
                    return AppAcross.ErrorPrefix + "No Data";
                }
            }

        }

        public async Task<string> AddPage(HttpMessage msg)
        {
            OraData ora = new OraData();
            string emsg = string.Empty;

            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("pageid", OracleDbType.Varchar2) { Size = 50, Value = msg.Parameters["pageid"] });
            parameters.Add(new OracleParameter("pagename", OracleDbType.Varchar2) { Size = 100, Value = msg.Parameters["pagename"] });
            parameters.Add(new OracleParameter("pagesort", OracleDbType.Int16) { Value = msg.Parameters["pagesort"] });

            List<string> sSql = new List<string>();
            sSql.Add(@"INSERT INTO XYSPAGE(PAGE_ID,PAGE_NAME,PAGE_SORT)
                            VALUES(:pageid, :pagename, :pagesort) ");

            emsg = await ora.PutData(sSql, parameters);
            if (emsg != string.Empty)
            {
                return AppAcross.ErrorPrefix + emsg;
            }
            else
            {
                return string.Empty;
            }

        }




    }
}