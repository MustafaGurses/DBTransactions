using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataBase;
using Interface.Fields;
namespace Interface
{
    public class Transactions : ITrial
    {
        public IEnumerable<object> GetAll(SqlCommand Command, SqlConnection Connection)
        {
            Command.Connection = Connection;
            using(var ReadData = Command.ExecuteReader())
            {
                while (ReadData.Read())
                    yield return ReadData;
            }
        }

        public object GetFirstData(SqlCommand Command, SqlConnection Connection)
        {
            using (Command)
            {
                Command.Connection = Connection;
                using(var ReadData = Command.ExecuteReader())
                {
                    if (ReadData.Read())
                        return ReadData.GetValue(0);
                    else
                        return "Veri Yok!";
                }
            }
        }
        public object GetData(SqlCommand Command,SqlConnection Connection,Enums.ReturnType ReturnType)
        {
            using (Command)
            {
                Command.Connection = Connection;
                using (Fields.Fields fd = new Fields.Fields())
                {
                    switch (ReturnType)
                    {
                        case Enums.ReturnType.String:
                            return Command.ExecuteScalar().ToString();
                        case Enums.ReturnType.Integer:
                            return int.TryParse(Command.ExecuteScalar().ToString(), out fd.ExecuteScalar_Int) ? fd.ExecuteScalar_Int : (int?)null;
                        case Enums.ReturnType.Double:
                            return double.TryParse(Command.ExecuteScalar().ToString(), out fd.ExecuteScalar_Double) ? fd.ExecuteScalar_Double : (double?)null;
                        case Enums.ReturnType.Float:
                            return float.TryParse(Command.ExecuteScalar().ToString(), out fd.ExecuteScalar_Float) ? fd.ExecuteScalar_Float : (float?)null;
                        case Enums.ReturnType.Long:
                            return long.TryParse(Command.ExecuteScalar().ToString(), out fd.ExecuteScalar_Long) ? fd.ExecuteScalar_Long : (long?)null;
                        case Enums.ReturnType.Boolean:
                            return bool.TryParse(Command.ExecuteScalar().ToString(), out fd.ExecuteScalar_Bool) ? fd.ExecuteScalar_Bool : (bool?)null;
                        default:
                            return "Return type algılanmadı !";
                    }
                }
            }
        }
        public DataTable GetTable(string Command,SqlConnection Connection)
        {
            using (var SqlCommand = new SqlCommand(Command, Connection))
            {
                using(var Adaptor = new SqlDataAdapter(SqlCommand))
                {
                    using (var Table = new DataTable())
                    {
                        try
                        {
                            Adaptor.Fill(Table);
                            return Table;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
