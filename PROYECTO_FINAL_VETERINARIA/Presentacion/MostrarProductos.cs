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
    public partial class MostrarProductos : Form
    {
        public MostrarProductos()
        {
            InitializeComponent();
        }

        private void MostrarProductos_Load(object sender, EventArgs e)
        {
            this.txtDescripccion.AutoSize = false;
            this.txtDescripccion.Size = new System.Drawing.Size(235, 60);
            mostrarProductos();
            mostrarCategorias();
        }

        public void mostrarProductos()
        {
            ProductosModel producto = new ProductosModel();
            dataGridView1.DataSource = producto.mostrarProductos();
        }

        public void mostrarCategorias()
        {
            ProductosModel producto = new ProductosModel();
            cmbCategoria.DataSource = producto.mostrarCategorias();
            cmbCategoria.DisplayMember = "NOMBRE_CATEGORIA";
            cmbCategoria.ValueMember = "ID_CATEGORIA";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductosModel producto = new ProductosModel();
            producto.insertarProducto(
                Convert.ToInt32(cmbCategoria.SelectedValue),
                txtNombreProd.Text,
                txtDescripccion.Text,
                (int)numCantidad.Value,
                float.Parse(txtPrecio.Text));

            MessageBox.Show("Producto Guardado con exito");
            mostrarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Eliminar Producto
            ProductosModel producto = new ProductosModel();
            producto.eliminarProducto(Convert.ToInt32(txtEliminar.Text));
            MessageBox.Show("Paciente Eliminado con exito");
            mostrarProductos();
            txtEliminar.Text = "";
        }

        //No
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Mandar id de producto a MostrarMascotaModifiacar
            MostrarMascotaModificar mmm = new MostrarMascotaModificar();
            mmm.ShowDialog();
        }
    }
}
