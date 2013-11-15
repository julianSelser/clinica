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

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        private Form padre;
        Profesional profesional;

        internal PedirTurno(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

    }
}
