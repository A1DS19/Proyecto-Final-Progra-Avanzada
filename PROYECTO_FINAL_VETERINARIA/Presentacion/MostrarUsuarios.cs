using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class MostrarUsuarios : Form
    {
        public MostrarUsuarios()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //Llenar dataGridView desde capa Logica
        private void mostrarUsuarios()
        {
            UserModel users = new UserModel();
            dataGridView1.DataSource = users.MostrarUsuarios();
        }

        private void MostrarUsuarios_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //Guardar Usuario
            UserModel user = new UserModel();
            user.insertarUsuario(
               txtUsuario.Text,
               txtContrasena.Text,
               txtNombre.Text,
               txtApellido.Text,
               txtPosicion.Text,
               txtEmail.Text);

            MessageBox.Show("Usuario Agregado con exito");
            mostrarUsuarios();

            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtPosicion.Text = "";
            txtEmail.Text = "";
        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton eliminar usuario
            UserModel user = new UserModel();
            user.eliminarUsuario(txtEliminar.Text);
            MessageBox.Show("Usuario eliminado con exito");
            mostrarUsuarios();
        }




        /*
        //No
        private void panelEditarPerfil_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPosicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        */


    }
}
