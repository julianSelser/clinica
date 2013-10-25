﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Helpers;
using Clinica_Frba.Login;

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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            FormHelper.mostrarNuevaVentana(new LoginForm(this), this);
        }

        public void setearUsuarioLogueado(String usuario)
        {
            if (usuario.Length > 0 && !usuario.Contains(""))
            {
                usuarioLogueado.Visible = true;
                usuarioLogueado.Text = "Logueado como: " + usuario;
            }
        }

        private void deslogButton_Click(object sender, EventArgs e)
        {
            usuarioLogueado.Visible = false;
        }
    }
}
