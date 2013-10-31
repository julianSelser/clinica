using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Generar_Receta
{
    public partial class Generar_Receta1 : Form
    {
        private Form padre;

        public Generar_Receta1(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
