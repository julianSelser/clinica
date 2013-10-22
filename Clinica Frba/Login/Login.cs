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
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pantallaPrincipal.Visible = true;
            pantallaPrincipal.Activate();
            pantallaPrincipal.Select();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            pantallaPrincipal.Show();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
