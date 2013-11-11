using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class AltaProfesional : Form
    {
        private Form padre;
        public AltaProfesional(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            for (int x = 1; x <= 20; x++)
            {
                checkedListBox1.Items.Add("Especialidad " + x.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

    }
}
