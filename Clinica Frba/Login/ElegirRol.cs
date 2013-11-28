using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;
using Clinica_Frba.Domain;

// encargada de dar a elegir el rol a un usuario que esta logeandose
namespace Clinica_Frba.Login
{
    public partial class ElegirRol : Form
    {
        PantallaPrincipal pantallaPrincipal;
        bool acepto = false; //variable que sabe si se presionó en aceptar, no se puede logear sin elegir un rol ni cancelar la ventana

        public ElegirRol(PantallaPrincipal padre)
        {
            InitializeComponent();
            this.pantallaPrincipal = padre;

            rolComboBox.DataSource = AppLogin.traerRoles(); //trae los roles del usuario
            rolComboBox.DisplayMember = "nombre";           //los muestra por nombre
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            acepto = true;

            if (rolComboBox.SelectedItem != null)
            {
                Rol rol = UsuarioLogeado.Instance.Rol = (Rol)rolComboBox.SelectedItem;

                UsuarioLogeado.Instance.Rol.funcionalidades = AppLogin.traerFuncionalidades();

                AppLogin.cargarUsuario();

                //setea el nombre de la persona o del rol si no tuviera una asociada
                if (rol.nombre == "Profesional" || rol.nombre == "Afiliado")
                    pantallaPrincipal.setearLogeo(UsuarioLogeado.Instance.Persona.nombre.ToUpper() + " " + UsuarioLogeado.Instance.Persona.apellido.ToUpper());
                else
                    pantallaPrincipal.setearLogeo(rol.nombre);

                pantallaPrincipal.habilitarFuncionalidades();
            }
            else
            {
                MessageBox.Show("El sistema no tiene guardado ningún rol para este usuario. Contacte a su administrador.");
            }

            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

        private void ElegirRol_FormClosing(object sender, FormClosingEventArgs e) //cuando se cierra la ventana...
        {
            e.Cancel = (acepto != true)? true : false; //si no acepto, no se puede salir de la ventana
        }
    }
}
