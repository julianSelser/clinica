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
using Clinica_Frba.Domain;

namespace Clinica_Frba
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
            deslogButton.Visible = false;
            deshabilitarFuncionalidades();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new LoginForm(this), this);
        }

        public void setearLogeo(String usuario)
        {
            if (usuario.Length > 0 && !Controlador.cadenaEsVaciaONull(usuario))
            {
                usuarioLabel.Visible = true;
                usuarioLabel.Text = usuario;
                loginButton.Visible = false;
                deslogButton.Visible = true;
            }
        }

        private void deslogButton_Click(object sender, EventArgs e)
        {
            deshabilitarFuncionalidades();
            usuarioLabel.Visible = false;
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
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Pedir Turno"), this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(FormCancelarFactory.abrirVentanaCancelaciones(this, UsuarioLogeado.Instance.Rol.nombre), this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new GenerarReceta(this), this);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new CompraBono(this), this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadosEstadisticos(this), this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new RegistrarAgenda(this), this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Registro Llegada"), this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new RegistroResultadoAtencion(this), this);
        }

        public void habilitarFuncionalidades() 
        {
            List<Funcionalidad> funcionalidades = UsuarioLogeado.Instance.Rol.funcionalidades;

            foreach (Funcionalidad funcion in funcionalidades) 
            {
                switch (funcion.id)
                {
                    case 1: button3.Visible = true; break;

                    case 3: button1.Visible = true; break;

                    case 4: button2.Visible = true; break;

                    case 7: button12.Visible = true; break;

                    case 8: button11.Visible = true; break;

                    case 9: button5.Visible = true; break;

                    case 10: button7.Visible = true; break;

                    case 11: button8.Visible = true; break;

                    case 12: button6.Visible = true; break;

                    case 13: button10.Visible = true; break;

                    case 14: button9.Visible = true; break;
                    
                    default: break;
                }
            }
            botonera.Visible = true;
        }

        public void deshabilitarFuncionalidades() 
        {
            foreach (Control control in botonera.Controls) 
            {
                control.Visible = false;
            }
                               
            botonera.Visible = false;
        }

    }
}
