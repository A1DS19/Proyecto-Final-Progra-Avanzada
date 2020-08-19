using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class MascotaDao: ConnectionSQL
    {
        SqlDataReader reader;
        DataTable tabla = new DataTable();

        public void insertarMascota(string nombre, int id_raza, string padecimiento, int edad)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into mascotas values('" + nombre + "','" + id_raza + "','" + padecimiento + "','" + edad + "')";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable MostrarRaza()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from razas";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }

    }
}
