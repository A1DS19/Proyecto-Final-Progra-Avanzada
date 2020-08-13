using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
   public class ProductosDao : ConnectionSQL
    {
        SqlDataReader reader;
        DataTable tabla = new DataTable();

        public DataTable mostrarProductos()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listarProductos";
                    command.CommandType = CommandType.StoredProcedure;

                    reader = command.ExecuteReader();
                    tabla.Load(reader);
                    reader.Close();

                    connection.Close();

                    return tabla;
                }
            }
        }//Fin Listar Productos.

        public DataTable mostrarCategorias()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM CATEGORIAS";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);
                    reader.Close();

                    connection.Close();

                    return tabla;
                }
            }
        }//Fin Listar Categorias.

        public void insertarProducto(int id_categoria, string nombre, string desc, int cantidad, float precio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into PRODUCTOS values('" + id_categoria + "','" + nombre + "','" + desc + "','" + cantidad + "','"+ precio+ "')";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }//Fin insertar Producto

        public void eliminarProducto(int id_producto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM PRODUCTOS WHERE ID_PRODUCTO ='" + id_producto + "'";

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }//Fin Eliminar Producto
    }
}
