using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Data.SqlClient;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Utils
{
    public class SqlData
    {
        public string SqlConnString = "Server=myServerAddress;Database=myDataBase;User Id=json;Password=tiger;";
         
        public SqlData() { }
        public SqlData(string ConnectionString)
        {
            SqlConnString = ConnectionString;
        }

        // ── GET DATA (DataTable) ──────────────────────────────────────────────
        public async Task<(DataTable dt, string emsg)> GetData(string sSql, List<SqlParameter> parameters = null)
        {
            string emsg = string.Empty;
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(SqlConnString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                try
                {
                    await conn.OpenAsync();

                    if (parameters != null && parameters.Count > 0)
                        foreach (var p in parameters) cmd.Parameters.Add(p);

                    var adapter = new SqlDataAdapter(cmd);
                    await Task.Run(() => adapter.Fill(dt));
                }
                catch (Exception ex)
                {
                    emsg = AppAcross.ErrorPrefix + ex.Message;
                }
            }

            return (dt, emsg);
        }

        // ── GET DATASET ───────────────────────────────────────────────────────
        public async Task<(DataSet ds, string emsg)> GetDataSet(string sSql, List<SqlParameter> parameters = null)
        {
            string emsg = string.Empty;
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(SqlConnString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                try
                {
                    await conn.OpenAsync();

                    if (parameters != null && parameters.Count > 0)
                        foreach (var p in parameters) cmd.Parameters.Add(p);

                    var adapter = new SqlDataAdapter(cmd);
                    await Task.Run(() => adapter.Fill(ds));
                }
                catch (Exception ex)
                {
                    emsg = AppAcross.ErrorPrefix + ex.Message;
                }
            }

            return (ds, emsg);
        }

        // ── PUT DATA (transaction) ────────────────────────────────────────────
        public async Task<string> PutData(List<string> sSql, List<SqlParameter> parameters = null)
        {
            string result = string.Empty;
            SqlTransaction tran = null;

            using (var conn = new SqlConnection(SqlConnString))
            using (var cmd = new SqlCommand())
            {
                try
                {
                    await conn.OpenAsync();

                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    if (parameters != null && parameters.Count > 0)
                        foreach (var p in parameters) cmd.Parameters.Add(p);

                    foreach (var sql in sSql)
                    {
                        if (!string.IsNullOrWhiteSpace(sql))
                        {
                            cmd.CommandText = sql;
                            await cmd.ExecuteNonQueryAsync();
                            cmd.Parameters.Clear();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    try { tran?.Rollback(); } catch { }
                    result = AppAcross.ErrorPrefix + ex.Message;
                }
            }

            return result;
        }

    }
}
