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
using Clinica_Frba.Abm_de_Rol;
using Clinica_Frba.Pedir_Turno;
using Clinica_Frba.Cancelar_Atencion;
using Clinica_Frba.Compra_de_Bono;
using Clinica_Frba.Generar_Receta;
using Clinica_Frba.Listados_Estadisticos;
using Clinica_Frba.Registrar_Agenda;
using Clinica_Frba.Registro_de_LLegada;
using Clinica_Frba.Registro_Resultado_Atencion;

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

        private void button3_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Rol(this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Profesional(this), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Afiliado(this), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Solicitar_Turno(this), this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Cancelacion_Atencion(this), this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Generar_Receta1(this), this);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Comprar_Bono(this), this);
        }
        

    }
}
