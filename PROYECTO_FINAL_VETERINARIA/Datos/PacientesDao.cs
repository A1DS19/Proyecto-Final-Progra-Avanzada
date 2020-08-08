using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class PacientesDao : ConnectionSQL
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
        }//Fin listar clientes.

        public DataTable MostrarTratamientos()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from TRATAMIENTOS";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }//Fin listar tratamientos

        public DataTable MostrarOperaciones()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from OPERACIONES";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }//Fin listar Operaciones

        public void insertarPaciente(int id_mascota, int id_cliente, int id_tratamiento, int id_operacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into PACIENTES_INTERNADOS values('" + id_mascota + "','" + id_cliente + "','" + id_tratamiento + "','" + id_operacion + "')";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }//Fin insertar Paciente

        public DataTable MostrarPacientes()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listarPacientes";
                    command.CommandType = CommandType.StoredProcedure;

                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }//Fin listar Operaciones

        public void eliminarPaciente(int id_paciente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM PACIENTES_INTERNADOS WHERE ID_PACIENTE ='" + id_paciente + "'";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }//Fin Eliminar Paciente
    }
}
