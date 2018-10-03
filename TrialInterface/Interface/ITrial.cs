using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace Interface
{
    interface ITrial
    {
        IEnumerable<object> GetAll(SqlCommand Command,SqlConnection Connection);
        object GetFirstData(SqlCommand Command,SqlConnection Connection);
        object GetData(SqlCommand Command, SqlConnection Connection, Enums.ReturnType ReturnType);
        DataTable GetTable(string Command, SqlConnection Connection);
    }
}
