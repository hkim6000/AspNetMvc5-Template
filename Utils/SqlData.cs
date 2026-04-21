using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Data.SqlClient;
using static AspNetMvc5.Utils.ApiRequest;

namespace AspNetMvc5.Utils
{
    public class SqlData
    {

        public string SqlConnString = "Server=myServerAddress;Database=myDataBase;User Id=json;Password=tiger;";

        public SqlData()
        {
        }
        public SqlData(string ConnectionString)
        {
            SqlConnString = ConnectionString;
        }

        private SqlConnection SqlConn;

        public async Task<(DataTable dt, string emsg)> GetData(string sSql, List<SqlParameter> parameters = null)
        {
            string emsg = string.Empty;
            DataTable dt = new DataTable();

            SqlConn = new SqlConnection(SqlConnString);

            using (var cmd = new SqlCommand())
            {
                try
                {
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();
                    }

                    cmd.Connection = SqlConn;
                    cmd.CommandText = sSql;

                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
                    adapter.Fill(dt);

                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }
                }
                catch (SystemException oe)
                {
                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }
                    emsg = AppAcross.ErrorPrefix + oe.Message;
                }
            }

            return (dt, emsg);
        }
        public async Task<(DataSet ds, string emsg)> GetDataSet(string sSql, List<SqlParameter> parameters = null)
        {
            string emsg = string.Empty;
            DataSet ds = new DataSet();

            SqlConn = new SqlConnection(SqlConnString);

            using (var cmd = new SqlCommand())
            {
                try
                {
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();
                    }

                    cmd.Connection = SqlConn;

                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    cmd.CommandText = sSql;

                    SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
                    adapter.Fill(ds);

                    cmd.Parameters.Clear();

                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }
                }
                catch (SystemException oe)
                {
                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }

                    emsg = AppAcross.ErrorPrefix + oe.Message;
                }
            }

            return (ds, emsg);
        }

        public async Task<string> PutData(List<string> sSql, List<SqlParameter> parameters = null)
        {
            string Results = string.Empty;
            SqlTransaction SqlTran = null;

            SqlConn = new SqlConnection(SqlConnString);

            using (var cmd = new SqlCommand())
            {
                try
                {
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();
                    }

                    cmd.Connection = SqlConn;
                    SqlTran = SqlConn.BeginTransaction();
                    cmd.Transaction = SqlTran;

                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    foreach (string sql in sSql)
                    {
                        if (!string.IsNullOrWhiteSpace(sql))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }

                    SqlTran.Commit();

                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }
                }
                catch (SystemException oe)
                {
                    try
                    {
                        SqlTran?.Rollback();
                    }
                    catch { }

                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                    }

                    Results = AppAcross.ErrorPrefix + oe.Message;
                }
            }
            return Results;
        }



    }
}