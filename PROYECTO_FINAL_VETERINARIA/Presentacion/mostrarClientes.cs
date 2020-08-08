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
    public partial class mostrarClientes : Form
    {
        public mostrarClientes()
        {
            InitializeComponent();
        }

        private void mostrarClientes_Load(object sender, EventArgs e)
        {
            ListarMascotas();
            mostrarClientess();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarMascotas mm = new MostrarMascotas();
            mm.ShowDialog();
        }

        private void mostrarClientess()
        {
            ClientesModel cliente = new ClientesModel();
            dataGridView1.DataSource = cliente.MostrarClientes();
        }

        //METODO PARA MOSTRAR DATOS EN COMBO BOX
        private void ListarMascotas()
        {
            ClientesModel cliente = new ClientesModel();
            cmbMascota.DataSource = cliente.ListarMascota();
            cmbMascota.DisplayMember = "NOMBRE";
            cmbMascota.ValueMember = "ID_MASCOTA";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            ClientesModel cliente = new ClientesModel();
            cliente.insertarCliente(
                txtCedula.Text,
                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                txtDireccion.Text,
                txtEmail.Text,
                Convert.ToInt32(cmbMascota.SelectedValue));

            txtNombre.Text = "";
            txtCedula.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            cmbMascota.Text = "";

            mostrarClientess();
        }
    }
}
