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

//Pantalla intermedia que permite dar las altas de conyuge y afiliados en caso de que corresponda y de modificar un afiliado

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class PeticionAccion : Form
    {
        private Form padre;
        private Afiliado afiliado;

        internal PeticionAccion(Afiliado afiliado, Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            deshabilitarBotones();
        }

        private void PeticionAccion_Activated(object sender, EventArgs e)
        {
            deshabilitarBotones();
        }
        private void altaConyuge_Click(object sender, EventArgs e)
        {
            ModoAfiliado modo = new ModoAfiliado();
            modo.modo = afiliado.estadoCivil;
            modo.nroAfiliado = afiliado.nroAfiliado;
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado(modo, this),this);
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

        private void deshabilitarBotones()
        {
            if (AppAfiliado.cantidadFamiliaresACargoRegistrados(afiliado) >= afiliado.cantFamiliaresACargo)
            {
                altaFamiliar.Enabled = false;
            }
            else altaFamiliar.Enabled = true;
            if (AppAfiliado.tieneConyuge(afiliado) || (afiliado.estadoCivil != "Casado/a" && afiliado.estadoCivil != "Concubinato"))
            {
                 altaConyuge.Enabled = false;
            }
            else altaConyuge.Enabled = true;
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarAfiliado(this, afiliado), this);
        }
    }
}
