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

//Funcionalidad de baja, las bajas son logicas y no fisicas, registrando la fecha en que se dio de baja al afiliado

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class BajaAfiliado : Form
    {
        private Form padre;
        private Afiliado afiliado;

        internal BajaAfiliado(Form padre, Afiliado afiliado)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            nroAfiliado.Text = afiliado.nroAfiliado.ToString();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            AppAfiliado.darBajaAfiliado(afiliado.nroAfiliado);
            MessageBox.Show("La baja se ha realizado correctamente.");
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

    }
}
