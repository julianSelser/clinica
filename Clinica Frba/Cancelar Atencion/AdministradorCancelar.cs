using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

// toma el template "BaseCancelarAtencion" y lo adapta para la cancelacion de turnos por un administrador
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class AdministradorCancelar : BaseCancelarAtencion
    {
        public AdministradorCancelar(Form padre) : base(padre)
        {
            InitializeComponent();
        }

        override protected bool camposValidos()
        {
            return cadenasBusquedaValidas(nombreTextBox.Text, nroDocTextBox.Text)
                && (tipoUsrSelector.Text == "Profesional" ? fechasValidas(desdeTextBox.Text, hastaTextBox.Text) : true);
        }

        override protected DataTable llenarGrilla() 
        {
            return AppCancelarAtencion.traerTablaPedida(nombreTextBox.Text
                                                        , tipoUsrSelector.Text
                                                        , nroDocTextBox.Text
                                                        , tipoDocSelector.Text
                                                        , Controlador.parsear(desdeTextBox.Text)
                                                        , Controlador.parsear(hastaTextBox.Text));
        }

        override protected string mensajeDeError() 
        {
            if (tipoUsrSelector.Text != "Profesional")
                return base.mensajeDeError();
            else
                return base.mensajeDeError() + " Las fechas tienen que que tener la forma DD/MM/AAAA además de que la fecha \"desde\" debe ser mayor a la fecha \"hasta\"";
        }

        override protected bool fechasValidas() 
        {
            return base.fechasValidas(desdeTextBox.Text, hastaTextBox.Text);
        }

        private void tipoUsrSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoUsrSelector.SelectedItem.ToString() != "Profesional")
            {
                desdeTextBox.Enabled = false;
                hastaTextBox.Enabled = false;
                cancelarPeriodo.Enabled = false;
            }
            else
            {
                desdeTextBox.Enabled = true;
                hastaTextBox.Enabled = true;
                cancelarPeriodo.Enabled = true;
            }
        }
    }
}
