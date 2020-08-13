using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
   public class ProductosModel
    {
        ProductosDao producto = new ProductosDao();

        public DataTable mostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = producto.mostrarProductos();
            return tabla;
        }

        public DataTable mostrarCategorias()
        {
            DataTable tabla = new DataTable();
            tabla = producto.mostrarCategorias();
            return tabla;
        }

        public void insertarProducto(int id_categoria, string nombre, string desc, int cantidad, float precio)
        {
            producto.insertarProducto(id_categoria, nombre, desc, cantidad, precio);
        }

        public void eliminarProducto(int id_producto)
        {
            producto.eliminarProducto(id_producto);
        }
    }
}
