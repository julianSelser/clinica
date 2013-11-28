using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

//encargada de cancelar los turnos de UN dia
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class SetearMotivoCancelacion : BaseSetearMotivo
    {
        private DataGridViewSelectedRowCollection seleccion;

        public SetearMotivoCancelacion(BaseCancelarAtencion padre, DataGridViewSelectedRowCollection seleccion): base(padre)
        {
            this.seleccion = seleccion;
        }

        override protected void accionarCancelacion() 
        {
            AppCancelarAtencion.cancelarAtencion(seleccion, motivoTextBox.Text);
        }
    }
}

