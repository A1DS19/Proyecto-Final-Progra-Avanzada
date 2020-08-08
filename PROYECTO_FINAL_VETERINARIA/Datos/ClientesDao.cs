using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
   public class ClientesDao : ConnectionSQL
    {
        SqlDataReader reader;
        DataTable tabla = new DataTable();
        public DataTable mostrarMascota()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM MASCOTAS";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);
                    reader.Close();

                    connection.Close();

                    return tabla;
                }
            }
        }//Fin Listar razas.

        public DataTable MostrarClientes()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from clientes";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }

        public void insertarCliente(string cedula, string nombre, string apellido, string telefono, string direccion, string correo, int id_mascota)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into CLIENTES values('" + cedula + "','" + nombre + "','" + apellido + "','" + telefono + "','" + direccion + "','" + correo +"','" + id_mascota + "')";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }//Fin insertar clientes
    }
}
