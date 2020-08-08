using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
    public class ClientesModel
    {
        ClientesDao clientesDao = new ClientesDao();

        public void insertarCliente(string cedula, string nombre, string apellido, string telefono, string direccion, string correo, int id_mascota)
        {
            clientesDao.insertarCliente(cedula, nombre, apellido, telefono, direccion, correo, id_mascota);
        }
        public DataTable ListarMascota()
        {
            DataTable tabla = new DataTable();
            tabla = clientesDao.mostrarMascota();
            return tabla;
        }

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = clientesDao.MostrarClientes();
            return tabla;
        }
    }
}