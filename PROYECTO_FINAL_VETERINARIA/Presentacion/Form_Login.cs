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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASENA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
            
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASENA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //Validacion de Login usuario
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtuser.Text != "USUARIO")
            {
                if(txtpass.Text != "CONTRASENA")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                    if(validLogin == true)
                    {
                        Form_Principal mainMenu = new Form_Principal();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        txtpass.Clear();
                        txtuser.Focus();
                    }
                    
                }
            }
        }

        //Cerrar sesion
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "CONTRASENA";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "USUARIO";
            txtuser.Clear();
            this.Show();
            txtuser.Focus();
        }
    }
}
