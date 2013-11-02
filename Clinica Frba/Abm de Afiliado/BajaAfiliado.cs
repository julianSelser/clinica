using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class BajaAfiliado : Form
    {
        private Form padre;

        public BajaAfiliado(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nro = Convert.ToInt32(nroAfiliado.Text);
            AppAfiliado.darBajaAfiliado(nro);
            MessageBox.Show("La baja se ha realizado correctamente.");
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

    }
}
