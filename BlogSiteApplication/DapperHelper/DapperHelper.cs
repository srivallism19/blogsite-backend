using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace UserBlogSite.DapperHelper
{
    public class DapperHelper : IDapperHelper
    {
        private static string connectionString= null;
        private static readonly object _lock= new();
        private static SqlConnection _conn = null;
        public DapperHelper(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SQLServer");
        }

        private static SqlConnection Conn
        {
            get
            {
                if(_conn == null || _conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
                {
                    lock (_lock)
                    {
                        _conn = new SqlConnection(connectionString);
                    }
                }
                return _conn;
            }
        }

        public async Task<IList<T>> QueryAsync<T>(string query, object parameters = null)
        {
            await Conn.OpenAsync();
            using (var tran = Conn.BeginTransaction())
            {
                try
                {
                    var res = await Conn.QueryAsync<T>(query, parameters, transaction: tran);
                    Conn.Close();
                    return res.ToList();
                }
                catch (Exception ex)
                {
                    Conn.Close();
                    throw ex;
                }
            }
        }

        public async Task<int> ExecuteAsync<T>(string query, object parameters = null)
        {
            await Conn.OpenAsync();
            using (var tran = Conn.BeginTransaction())
            {
                try
                {
                    var res = await Conn.ExecuteAsync(query, parameters, transaction: tran);
                    tran.Commit();
                    Conn.Close();
                    return res;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Conn.Close();
                    throw ex;
                }
            }
        }
    }
}
