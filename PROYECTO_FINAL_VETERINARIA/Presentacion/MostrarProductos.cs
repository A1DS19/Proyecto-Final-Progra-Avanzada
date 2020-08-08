using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linklVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
