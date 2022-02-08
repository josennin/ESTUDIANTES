using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ESTUDIANTES
{
    class conexion
    {
        public static SqlConnection Conectar()
        {
            string cadena = @"Data Source=JOSE\SQL_JOSE;Initial Catalog=REGISTRO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            return conn;
        }
    }
}
