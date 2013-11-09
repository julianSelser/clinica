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
            passTextBox.Text = "";
            passTextBox.PasswordChar = '*';
            passTextBox.MaxLength = 16;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            pantallaPrincipal.setearUsuarioLogueado(usrNameTextBox.Text);
            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

    }
}
