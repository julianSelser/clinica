using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

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
            return cadenasBusquedaValidas(nombreTextBox.Text, nroDocTextBox.Text)
                && fechasValidas(desdeTextBox.Text, hastaTextBox.Text);
        }

        protected override DataTable llenarGrilla()
        {
            return AppCancelarAtencion.traerTablaPedida(nombreTextBox.Text
                                                        , "Profesional"
                                                        , nroDocTextBox.Text
                                                        , tipoDocSelector.Text
                                                        , Controlador.parsear(desdeTextBox.Text)
                                                        , Controlador.parsear(hastaTextBox.Text));
        }
        
    }
}
