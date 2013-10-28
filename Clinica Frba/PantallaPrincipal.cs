using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.AppModel;
using Clinica_Frba.Login;
using Clinica_Frba.Abm_de_Afiliado;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            usuarioLogueado.Visible = false;
            deslogButton.Visible = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new LoginForm(this), this);
        }

        public void setearUsuarioLogueado(String usuario)
        {
            if (usuario.Length > 0 && !usuario.Contains(" "))
            {
                usuarioLogueado.Visible = true;
                usuarioLogueado.Text = "Logueado como: " + usuario;
                loginButton.Visible = false;
                deslogButton.Visible = true;
            }
        }

        private void deslogButton_Click(object sender, EventArgs e)
        {
            usuarioLogueado.Visible = false;
            deslogButton.Visible = false;
            loginButton.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Afiliado(this), this);
        }

        private void boton_profesional_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Profesional(this), this);
        }


    }
}
