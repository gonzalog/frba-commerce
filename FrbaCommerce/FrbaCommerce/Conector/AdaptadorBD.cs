using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FrbaCommerce.Conector
{
    class AdaptadorBD
    {
        public static void EjecutarProcedimiento(string proc, Dictionary<string,object> args)
        {
            SqlCommand comando = new SqlCommand()
            {
                Connection = new SqlConnection()
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString
                }
            };
            comando.Connection.Open();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "THE_DISCRETABOY." + proc;

            foreach (KeyValuePair<string, object> entry in args)
            {
                comando.Parameters.AddWithValue(entry.Key, entry.Value);
            }

            comando.ExecuteNonQuery();

            comando.Connection.Close();
        }

    }
}
