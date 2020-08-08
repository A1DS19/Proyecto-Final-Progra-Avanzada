using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Comun.cache;

namespace Datos
{
    
   public class UserDao:ConnectionSQL
    {
        SqlDataReader reader;
        DataTable tabla = new DataTable();

        //Mostrar Usuarios
        public DataTable MostrarUsuarios()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users";
                         
                    reader = command.ExecuteReader();
                    tabla.Load(reader);


                    return tabla;
                }
            }
        }

        //Eliminar Usuarios

        public void eliminarUsuario(string user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Users WHERE LoginName ='"+user+"'";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        //Insertar Usuarios
        //El comand text es mejor sin comand.parameters

        public void insertarUsuarios(string user, string pass, string nombre, string apellido, string position, string email)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Users values('"+user+"','"+pass+"','"+nombre+"','"+apellido+"','"+position+"','"+email+"')";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }


        //Editar Perfil
        public void editarPerfil(int id, string user, string pass, string nombre, string apellido,string position ,string email)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Users set LoginName=@userName,password=@password,Nombre=@nombre,Apellido=@apellido,Position=@position,Email=@email where UserId=@userId";
                    
                    command.Parameters.AddWithValue("@userName", user);
                    command.Parameters.AddWithValue("@password", pass);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@userId", id);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

            }
        }

        //Login Usuario 
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where LoginName=@user and Password=@pass";

                    //Declarar parametros
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);

                    command.CommandType = CommandType.Text;
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //Mientras lector lee las filas se agregar valores a columna de datos
                        while (reader.Read())
                        {
                            LoginUsuarioCache.UserId = reader.GetInt32(0);
                            LoginUsuarioCache.UserName = reader.GetString(1);
                            LoginUsuarioCache.PassWord = reader.GetString(2);
                            LoginUsuarioCache.Nombre = reader.GetString(3);
                            LoginUsuarioCache.Apellido = reader.GetString(4);
                            LoginUsuarioCache.Posicion = reader.GetString(5);
                            LoginUsuarioCache.Email = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
