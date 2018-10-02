using System;
using System.Data.SqlClient;

namespace DataBase
{
    public class Command : IDisposable
    {
        public SqlCommand SqlCommand(string CommandText)
        {
            using(System.Data.SqlClient.SqlCommand Com = new System.Data.SqlClient.SqlCommand())
            {
                Com.CommandText = CommandText;
                return Com;
            }
        }
        public SqlCommand SqlCommand(string CommandText,SqlParameterCollection[] Params = null)
        {
            using(System.Data.SqlClient.SqlCommand Com = new System.Data.SqlClient.SqlCommand())
            {
                Com.CommandText = CommandText;
                Com.Parameters.AddRange(Params);
                return Com;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        public virtual void Dispose(bool _IDispose)
        {
            if (_IDispose)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
