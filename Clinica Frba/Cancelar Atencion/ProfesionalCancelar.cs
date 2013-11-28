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
        }

        override protected bool camposValidos()
        {
            return fechasValidas(desdeTextBox.Text, hastaTextBox.Text);
        }

        protected override DataTable llenarGrilla()
        {
            Persona p = UsuarioLogeado.Instance.Persona;

            return AppCancelarAtencion.traerDiasDeProfesional(p.nombre
                                                            , p.apellido
                                                            , p.nroDoc
                                                            , p.tipoDoc
                                                            , Controlador.parsear(desdeTextBox.Text)
                                                            , Controlador.parsear(hastaTextBox.Text));
        }
        
    }
}
