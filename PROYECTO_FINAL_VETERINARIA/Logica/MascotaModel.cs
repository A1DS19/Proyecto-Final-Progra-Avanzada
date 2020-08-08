using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using Capa_Comun.cache;

namespace Logica
{
   public class MascotaModel
    {
        MascotaDao mascotaDao = new MascotaDao();

        public void insertarMascota(string nombre, int id_raza, string padecimiento, int edad)
        {
            mascotaDao.insertarMascota(nombre, id_raza, padecimiento, edad);
        }
        public DataTable ListarRazas()
        {
            DataTable tabla = new DataTable();
            tabla = mascotaDao.MostrarRaza();
            return tabla;
        }
    }
}
