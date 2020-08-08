using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public abstract class ConnectionSQL
    {
        //CONEXION A SQL.
        private readonly string connectionString;
        public ConnectionSQL()
        {
            connectionString = "Server=DESKTOP-AEEAP11\\SQLEXPRESS;DataBase=VETERINARIA; integrated security= true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
