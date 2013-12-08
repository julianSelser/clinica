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
            desdePicker.Value = Globales.getFechaSistema().AddDays(1);
            hastaPicker.Value = Globales.getFechaSistema().AddDays(2);
        }

        override protected bool camposValidos()
        {
            return cadenasBusquedaValidas(nombreTextBox.Text, nroDocTextBox.Text)
                && (tipoUsrSelector.Text == "Profesional" ? fechasValidas(desdePicker.Value, hastaPicker.Value) : true);
        }

        override protected DataTable llenarGrilla() 
        {
            return AppCancelarAtencion.traerTablaPedida(nombreTextBox.Text
                                                        , tipoUsrSelector.Text
                                                        , nroDocTextBox.Text
                                                        , tipoDocSelector.Text
                                                        , desdePicker.Value
                                                        , hastaPicker.Value);
        }

        override protected string mensajeDeError() 
        {
            if (tipoUsrSelector.Text != "Profesional")
                return base.mensajeDeError();
            else
            {
                if (!base.fechasValidas(desdePicker.Value, hastaPicker.Value))
                    return "No pueden buscarse para cancelar turnos de la fecha o anteriores y el intervalo debe ser correcto. ";
                else
                    return base.mensajeDeError();
            }
        }

        override protected bool fechasValidas() 
        {
            return base.fechasValidas(desdePicker.Value, hastaPicker.Value);
        }

        private void tipoUsrSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoUsrSelector.SelectedItem.ToString() != "Profesional")
            {
                desdePicker.Enabled = false;
                hastaPicker.Enabled = false;
                cancelarPeriodo.Enabled = false;
            }
            else
            {
                desdePicker.Enabled = true;
                hastaPicker.Enabled = true;
                cancelarPeriodo.Enabled = true;
            }
        }
    }
}
