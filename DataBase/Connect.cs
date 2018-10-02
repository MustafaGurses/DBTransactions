using System;
using System.Data.SqlClient;

namespace DataBase
{
    public class Connect : IDisposable
    {
        public static SqlConnection Connection = new SqlConnection();
        private static string _ConnectionString;
        public Connect(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
           if(Connection.State == System.Data.ConnectionState.Closed)
                Connection.ConnectionString = _ConnectionString;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool _Dispose)
        {
            if (_Dispose)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
