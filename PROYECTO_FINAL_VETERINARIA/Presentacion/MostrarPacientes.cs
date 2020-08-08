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
    public partial class MostrarPacientes : Form
    {
        public MostrarPacientes()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MostrarPacientes_Load(object sender, EventArgs e)
        {
            ListarPacientes();
            ListarClientes();
            ListarMascotas();
            ListarTratamientos();
            ListarOperaciones();
        }

        private void ListarPacientes()
        {
            PacientesModel paciente = new PacientesModel();
            dataGridView1.DataSource = paciente.MostrarPacientes();
        }

        private void ListarClientes()
        {
            PacientesModel paciente = new PacientesModel();
            cmbDueno.DataSource = paciente.MostrarClientes();
            cmbDueno.DisplayMember = "NOMBRE";
            cmbDueno.ValueMember = "ID_CLIENTE";
        }

        private void ListarMascotas()
        {
            ClientesModel cliente = new ClientesModel();
            cmbMascota.DataSource = cliente.ListarMascota();
            cmbMascota.DisplayMember = "NOMBRE";
            cmbMascota.ValueMember = "ID_MASCOTA";
        }

        private void ListarTratamientos()
        {
            PacientesModel paciente = new PacientesModel();
            cmbTratamiento.DataSource = paciente.MostrarTratamientos();
            cmbTratamiento.DisplayMember = "NOMBRE_TRATAMIENTO";
            cmbTratamiento.ValueMember = "ID_TRATAMIENTO";
        }
        private void ListarOperaciones()
        {
            PacientesModel paciente = new PacientesModel();
            cmbOperacion.DataSource = paciente.MostrarOperaciones();
            cmbOperacion.DisplayMember = "NOMBRE_OPERACION";
            cmbOperacion.ValueMember = "ID_OPERACION";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //No
        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //No
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PacientesModel paciente = new PacientesModel();

            paciente.insertarPaciente(
                Convert.ToInt32(cmbMascota.SelectedValue),
                Convert.ToInt32(cmbDueno.SelectedValue),
                Convert.ToInt32(cmbTratamiento.SelectedValue),
                Convert.ToInt32(cmbOperacion.SelectedValue)
                );
            MessageBox.Show("Paciente Agregado con exito");
            ListarPacientes();

        }

        private void linklVolver_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //Eliminar paciente
        private void button1_Click(object sender, EventArgs e)
        {
            PacientesModel paciente = new PacientesModel();
            paciente.eliminarPaciente(Convert.ToInt32(txtEliminar.Text));
            MessageBox.Show("Paciente Eliminado con exito");
            ListarPacientes();
            txtEliminar.Text = "";
        }
    }
}
