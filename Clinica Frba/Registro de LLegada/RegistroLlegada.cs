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

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class RegistroLlegada : Form
    {
        private Form padre;
        Profesional profesional;

        internal RegistroLlegada(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }


    }
}
