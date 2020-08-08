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
using Capa_Comun.cache;

namespace Presentacion
{
    public partial class Form_Principal : Form
    {
        public Form_Principal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }


        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //ABRIR FORMULARIO EN PANEL

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
                                                                                     //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        //ABRIR FORMULARIOS AJENOS AL ACTUAL:
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormUsuario>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<Form3>();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //On Load
        private void Form_Principal_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            lblNombre.Text = LoginUsuarioCache.Nombre + " "+ LoginUsuarioCache.Apellido;
            lblEmail.Text = LoginUsuarioCache.Email;
            lblPosicion.Text = LoginUsuarioCache.Posicion;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        //Ver Datos
        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<MostrarUsuarios>();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<mostrarClientes>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MostrarPacientes>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MostrarProductos>();
        }
    }
}
