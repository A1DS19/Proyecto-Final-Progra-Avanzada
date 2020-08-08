using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
   public class PacientesModel
    {
        PacientesDao paciente = new PacientesDao();

        public DataTable ListarMascota()
        {
            DataTable tabla = new DataTable();
            tabla = paciente.mostrarMascota();
            return tabla;
        }

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = paciente.MostrarClientes();
            return tabla;
        }

        public DataTable MostrarTratamientos()
        {
            DataTable tabla = new DataTable();
            tabla = paciente.MostrarTratamientos();
            return tabla;
        }

        public DataTable MostrarOperaciones()
        {
            DataTable tabla = new DataTable();
            tabla = paciente.MostrarOperaciones();
            return tabla;
        }

        public DataTable MostrarPacientes()
        {
            DataTable tabla = new DataTable();
            tabla = paciente.MostrarPacientes();
            return tabla;
        }

        public void insertarPaciente(int id_mascota, int id_cliente, int id_tratamiento, int id_operacion)
        {
            paciente.insertarPaciente(id_mascota, id_cliente, id_tratamiento, id_operacion);
        }

        public void eliminarPaciente(int id_paciente)
        {
            paciente.eliminarPaciente(id_paciente);
        }
    }
}
