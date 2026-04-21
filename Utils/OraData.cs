using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Utils
{
    public class OraData
    {

        public string OraConnString = "User Id=[username];Password=[password];Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=[hostname])(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=[service_name])));";

        public OraData()
        {
        }
        public OraData(string ConnectionString)
        {
            OraConnString = ConnectionString;
        }

        private OracleConnection OraConn;
         

        public async Task<(DataTable dt, string emsg)> GetData(string sSql, List<OracleParameter> parameters = null)
        {
            string emsg = string.Empty;
            DataTable dt = new DataTable();

            using (var OraConn = new OracleConnection(OraConnString))
            {
                using (var cmd = new OracleCommand())
                {
                    try
                    {
                        await OraConn.OpenAsync();

                        cmd.Connection = OraConn;
                        cmd.BindByName = true;
                        cmd.CommandText = sSql;

                        if (parameters != null && parameters.Count > 0)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        emsg = AppAcross.ErrorPrefix + ex.Message;
                    }
                }
            }

            return (dt, emsg);
        }
        public async Task<(DataSet ds, string emsg)> GetDataSet(List<string> sSql, List<OracleParameter> parameters)
        {
            string emsg = string.Empty;
            DataSet ds = new DataSet();

            using (var OraConn = new OracleConnection(OraConnString))
            {
                using (var cmd = new OracleCommand())
                {
                    try
                    {
                        await OraConn.OpenAsync();

                        cmd.Connection = OraConn;
                        cmd.BindByName = true;

                        for (int i = 0; i < sSql.Count; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(sSql[i]))
                            {
                                cmd.CommandText = sSql[i];
                                cmd.Parameters.Clear(); // clear before each sql

                                if (parameters != null && parameters.Count > 0)
                                {
                                    foreach (var param in parameters)
                                    {
                                        cmd.Parameters.Add(param);
                                    }
                                }

                                using (var reader = await cmd.ExecuteReaderAsync())
                                {
                                    DataTable dt = new DataTable();
                                    dt.TableName = $"Table{i}";
                                    dt.Load(reader);
                                    ds.Tables.Add(dt);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        emsg = AppAcross.ErrorPrefix + ex.Message;
                    }
                }
            }

            return (ds, emsg);
        }

        public async Task<string> PutData(List<string> sSql, List<OracleParameter> parameters = null)
        {
            string Results = string.Empty;

            using (var OraConn = new OracleConnection(OraConnString))
            {
                await OraConn.OpenAsync();
                using (var OraTran = OraConn.BeginTransaction())
                {
                    using (var cmd = new OracleCommand())
                    {
                        cmd.Connection = OraConn;
                        cmd.Transaction = OraTran;
                        cmd.BindByName = true;

                        try
                        {
                            foreach (string sql in sSql)
                            {
                                if (!string.IsNullOrWhiteSpace(sql))
                                {
                                    cmd.CommandText = sql;
                                    cmd.Parameters.Clear(); // clear before each sql

                                    if (parameters != null && parameters.Count > 0)
                                    {
                                        foreach (var param in parameters)
                                        {
                                            cmd.Parameters.Add(param);
                                        }
                                    }

                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }

                            OraTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                OraTran.Rollback();
                            }
                            catch { }

                            Results = AppAcross.ErrorPrefix + ex.Message;
                        }
                    }
                }
            }

            return Results;
        }





    }
}