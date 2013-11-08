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
    public partial class AfiliadoCancelar : BaseCancelarAtencion
    {
        public AfiliadoCancelar(Form padre): base(padre)
        {
            InitializeComponent();
            cancelarAtencion.Location = new Point(
                                        (volver.Location.X + buscar.Location.X)/2,
                                        cancelarAtencion.Location.Y);
            cancelarPeriodo.Visible = false;
            cancelarPeriodo.Enabled = false;

        }

        override protected bool camposValidos() 
        {
            return cadenasBusquedaValidas(nombreTextBox.Text, nroDocTextBox.Text);
        }

        override protected DataTable llenarGrilla() 
        {
            return AppCancelarAtencion.traerTablaPedida(nombreTextBox.Text, "Afiliado", nroDocTextBox.Text, tipoDocSelector.Text, null, null);
        }
    }
}
