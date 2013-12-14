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

// toma el template "BaseCancelarAtencion" y lo adapta para la cancelacion de turnos por un profesional
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class ProfesionalCancelar : BaseCancelarAtencion
    {
        public ProfesionalCancelar(Form padre):base(padre)
        {
            InitializeComponent();
            desdePicker.Value = Globales.getFechaSistema().AddDays(1);
            hastaPicker.Value = Globales.getFechaSistema().AddDays(2);
        }

        protected override string mensajeDeError()
        {
            return "intervalo inválido.";
        }

        override protected bool camposValidos()
        {
            return fechasValidas(desdePicker.Value, hastaPicker.Value);
        }

        protected override DataTable llenarGrilla()
        {
            Persona p = UsuarioLogeado.Instance.Persona;

            return AppCancelarAtencion.traerDiasDeProfesional(p.nombre
                                                            , p.apellido
                                                            , p.nroDoc
                                                            , p.tipoDoc
                                                            , desdePicker.Value
                                                            , hastaPicker.Value);
        }
        
    }
}
