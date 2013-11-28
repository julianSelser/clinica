using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

//Funcionalidad que permite dar de alta, baja y modificar un profesional
//Cada funcionalidad se delega en otra pantalla

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ABM_Profesional : Form
    {
        private Form padre;

        public ABM_Profesional(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaProfesional(this), this);
        }

        private void bajaButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Baja"), this);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Modificar"), this);
        }
    }
}
