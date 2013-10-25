using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba;

namespace Clinica_Frba.Login
{
    public partial class LoginForm : Form
    {
        PantallaPrincipal pantallaPrincipal;

        public LoginForm(PantallaPrincipal principal)
        {
            pantallaPrincipal = principal;
            InitializeComponent();
            InitializePassword();

        }

        private void InitializePassword()
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 16;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pantallaPrincipal.Visible = true;
            pantallaPrincipal.Activate();
            pantallaPrincipal.Select();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            pantallaPrincipal.setearUsuarioLogueado(textBox1.Text);
            pantallaPrincipal.Show();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pantallaPrincipal.Show();
            this.Close();
        }
    }
}
