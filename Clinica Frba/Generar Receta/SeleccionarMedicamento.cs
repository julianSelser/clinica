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

namespace Clinica_Frba.Generar_Receta
{
    public partial class SeleccionarMedicamento : Form
    {
        Form padre;

        public SeleccionarMedicamento(Form padre, Medicamento medicamento)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nroMedicamentoBox.Clear();
            descripcionBox.Clear();
        }

    }
}
