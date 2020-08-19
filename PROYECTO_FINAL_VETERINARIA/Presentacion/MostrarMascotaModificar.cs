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
    public partial class MostrarMascotaModificar : Form
    {
        public MostrarMascotaModificar()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MostrarMascotaModificar_Load(object sender, EventArgs e)
        {
            MascotaModel mascota = new MascotaModel();
        }
    }
}
