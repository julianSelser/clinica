using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

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

        private void acceptButton_Click(object sender, EventArgs e)
        {
            pantallaPrincipal.setearUsuarioLogueado(textBox1.Text);
            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

    }
}
