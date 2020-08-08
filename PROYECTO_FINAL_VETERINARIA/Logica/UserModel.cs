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
    public class UserModel
    {
        UserDao userDao = new UserDao();

        //Atributos Usuario
        private int id;
        private string user;
        private string pass;
        private string nombre;
        private string apellido;
        private string position;
        private string email;

        public UserModel(int id, string user, string pass, string nombre, string apellido, string position, string email)
        {
            this.id = id;
            this.user = user;
            this.pass = pass;
            this.nombre = nombre;
            this.apellido = apellido;
            this.position = position;
            this.email = email;
        }

        public UserModel()
        {

        }

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public string editarUsuario()
        {
            userDao.editarPerfil(id, user, pass, nombre, apellido, position, email);
            LoginUser(user, pass);

            return "Perfil actualizado con exito";
        }

        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = userDao.MostrarUsuarios();
            return tabla;
        }

        public void insertarUsuario(string user, string pass, string nombre, string apellido, string position, string email)
        {
            userDao.insertarUsuarios(user, pass, nombre, apellido, position, email);
            
        }

        public void eliminarUsuario(string user)
        {
            userDao.eliminarUsuario(user);
        }
    }
}
