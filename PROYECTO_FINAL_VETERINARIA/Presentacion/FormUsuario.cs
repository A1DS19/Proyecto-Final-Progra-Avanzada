using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Comun.cache;
using Logica;

namespace Presentacion
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cargarDatosUsuario();
        }

        private void cargarDatosUsuario()
        {
            //Vista al iniciar panel de editar usuario
            lblUser.Text = LoginUsuarioCache.UserName;
            lblNombre.Text = LoginUsuarioCache.Nombre + " " + LoginUsuarioCache.Apellido;
            lblEmail.Text = LoginUsuarioCache.Email;
            lblPosicion.Text = LoginUsuarioCache.Posicion;

            //Panel Editar

            txtUsuario.Text = LoginUsuarioCache.UserName;
            txtNombre.Text = LoginUsuarioCache.Nombre;
            txtApellido.Text = LoginUsuarioCache.Apellido;
            txtPass.Text = LoginUsuarioCache.PassWord;
            txtEmail.Text = LoginUsuarioCache.Email;
            txtPosicion.Text = LoginUsuarioCache.Posicion;
        }

        private void linkLEditarPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEditarPerfil.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            cargarDatosUsuario();
        }

        //int id, string user, string pass, string nombre, string apellido, string position, string email

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var userModel = new UserModel(
                id:LoginUsuarioCache.UserId, 
                user: txtUsuario.Text,
                pass: txtPass.Text,
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                position: txtPosicion.Text,
                email: txtEmail.Text);
                
            var result = userModel.editarUsuario();
            MessageBox.Show(result);
            panelEditarPerfil.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
