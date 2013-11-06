using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Domain;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class PeticionAlta : Form
    {
        private Form padre;
        private Afiliado afiliado;

        internal PeticionAlta(Afiliado afiliado, Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            afiliado.nroAfiliado = AppAfiliado.buscarNroAfiliado(afiliado);
        }

        private void altaConyuge_Click(object sender, EventArgs e)
        {
            ModoAfiliado modo = new ModoAfiliado();
            modo.modo = afiliado.estadoCivil;
            modo.nroAfiliado = afiliado.nroAfiliado;
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado(modo,this),this);
        }

        private void altaFamiliar_Click(object sender, EventArgs e)
        {
            ModoAfiliado modo = new ModoAfiliado();
            modo.modo = "Familiar";
            modo.nroAfiliado = afiliado.nroAfiliado;
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado(modo, this), this);
        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
