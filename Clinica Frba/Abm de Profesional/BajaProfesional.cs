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

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class BajaProfesional : Form
    {
        private Form padre;
        internal Profesional profesional;

        internal BajaProfesional(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
            this.idBox.Text = profesional.id.ToString();

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AppProfesional.darBajaProfesional(profesional);
            MessageBox.Show("La baja se ha realizado correctamente.");
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
