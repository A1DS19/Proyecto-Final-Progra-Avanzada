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
    public partial class MostrarMascotas : Form
    {
        public MostrarMascotas()
        {
            InitializeComponent();
        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void MostrarMascotas_Load(object sender, EventArgs e)
        {
            ListarRazas();
        }


        //METODO PARA MOSTRAR DATOS EN COMBO BOX
        private void ListarRazas()
        {
            MascotaModel mascota = new MascotaModel();
            cmbRaza.DataSource = mascota.ListarRazas();
            cmbRaza.DisplayMember = "RAZAS";
            cmbRaza.ValueMember = "ID_RAZAS";
        }

        //Hay que convertir txt de combo box a int mediante  Convert.ToInt32().
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MascotaModel mascota = new MascotaModel();
            mascota.insertarMascota(txtNombre.Text,
              Convert.ToInt32(cmbRaza.SelectedValue),
                txtPadecimiento.Text,
                Int32.Parse(txtEdad.Text));

            MessageBox.Show("Mascota Agregada con exito");
            txtNombre.Text = "";
            txtPadecimiento.Text = "";
            cmbRaza.Text = "";
            txtEdad.Text = "";

            this.Close();
        }
    }
}
