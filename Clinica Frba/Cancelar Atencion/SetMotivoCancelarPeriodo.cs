using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

// encargada de cancelar los motivos de un periodo
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class SetMotivoCancelarPeriodo : BaseSetearMotivo
    {
        private DataTable periodo;

        public SetMotivoCancelarPeriodo() { InitializeComponent(); }

        public SetMotivoCancelarPeriodo(BaseCancelarAtencion padre, DataTable periodo):base(padre)
        {
            this.periodo = periodo;
        }

        override protected void accionarCancelacion()
        {
            AppCancelarAtencion.cancelarPeriodo(periodo, motivoTextBox.Text);
        }
    }
}
