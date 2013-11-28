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

//Pantalla principal de la aplicacion, primero de debe loguear con un usuario y contraseña
//para hacer uso de las funcionalidades, mostrando solo los botones de las permitidas para ese usuario

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
            AsistenteVistas.mostrarNuevaVentana(new PedirTurno(this), this);
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
            AsistenteVistas.mostrarNuevaVentana(new RegistroLlegada(this), this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoConsultas(this, "Resultados"), this);
        }

        public void habilitarFuncionalidades() 
        {
            List<Funcionalidad> funcionalidades = UsuarioLogeado.Instance.Rol.funcionalidades;

            habilitarFuncionalidades(funcionalidades);

            botonera.Visible = true;
        }

        // setea la visibilidad de un boton para una funcionalidad segun un booleano
        public void setearFuncionalidad(int idFuncionalidad, bool booleano) 
        {
            switch (idFuncionalidad)
            {
                case 1: button3.Visible = booleano; break;

                case 3: button1.Visible = booleano; break;

                case 4: button2.Visible = booleano; break;

                case 7: button12.Visible = booleano; break;

                case 8: button11.Visible = booleano; break;

                case 9: button5.Visible = booleano; break;

                case 10: button7.Visible = booleano; break;

                case 11: button8.Visible = booleano; break;

                case 12: button6.Visible = booleano; break;

                case 13: button10.Visible = booleano; break;

                case 14: button9.Visible = booleano; break;

                default: break;
            }
        }

        public void habilitarFuncionalidad(int idFuncionalidad) { setearFuncionalidad(idFuncionalidad, true); }

        public void deshabilitarFuncionalidad(int idFuncionalidad) { setearFuncionalidad(idFuncionalidad, false); }

        public void habilitarFuncionalidades(List<Funcionalidad> funcionalidades) 
        {
            foreach (Funcionalidad funcion in funcionalidades) 
            {
                habilitarFuncionalidad(funcion.id);
            }
        }

        public void deshabilitarFuncionalidades() 
        {
            foreach (Control control in botonera.Controls)
            {
                control.Visible = false;
            }
        }

    }
}
