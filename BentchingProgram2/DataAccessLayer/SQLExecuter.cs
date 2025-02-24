using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class SQLExecuter
    {
        private static string ConnectionString = "";

        public static void SetConn(string conn)
        {
            ConnectionString = conn;
        }

        public static SqlCommand GetSqlCommand(string sproc)
        {
            SqlCommand cmd = new SqlCommand(sproc);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                using (SqlConnection conn = new(ConnectionString))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    SqlCommandBuilder.DeriveParameters(cmd);
                }
                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async static Task<SqlDataReader> ExecuteSqlRead(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                cmd.Connection = conn;
                await conn.OpenAsync();
                Debug.Print(GetRunningSql(cmd));
                return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task ExecuteSqlCrud(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    cmd.Connection = conn;
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task<List<T>> GetDBResultList<T>(SqlCommand cmd) where T : new()
        {
            List<T> lst = new();
            List<PropertyInfo> props = typeof(T).GetProperties().ToList();

            using (SqlDataReader dr = await ExecuteSqlRead(cmd))
            {
                while (dr.Read())
                {
                    T item = new T();
                    foreach (PropertyInfo p in props)
                    {
                        if (p.CanWrite)
                        {
                            var dbval = dr[p.Name];
                            p.SetValue(item, dbval is DBNull ? null : dbval);
                        }
                    }
                    lst.Add(item);
                }
            }

            return lst;
        }

        private static string GetRunningSql(SqlCommand cmd)
        {
            string val = "";
#if DEBUG
            StringBuilder sb = new();

            if (cmd.Connection != null)
            {
                sb.AppendLine($"-- {cmd.Connection.DataSource}");
                sb.AppendLine($"use {cmd.Connection.Database}");
                sb.AppendLine("go");
                if (cmd.CommandType == CommandType.StoredProcedure)
                {
                    sb.AppendLine($"exec {cmd.CommandText}");
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        sb.AppendLine($"{p.ParameterName} = {p.Value}");
                    }
                }
                else
                {
                    sb.AppendLine(cmd.CommandText);
                }

                val = sb.ToString();
            }
#endif
            return val;
        }

    }
}
