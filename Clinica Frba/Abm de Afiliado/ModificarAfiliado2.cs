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
    public partial class ModificarAfiliado2 : Form
    {
        private ModificarAfiliado padre;

        public ModificarAfiliado2(ModificarAfiliado padre)
        {
            InitializeComponent();
            this.padre = padre;
            habilitarBotonesSegunTipo(padre);
        }

        private void habilitarBotonesSegunTipo(ModificarAfiliado padre)
        {
            int retorno = tipoAfiliado(padre.numeroAfiliado);

            cantFamiliares.Visible = false;
            labelFamiliares.Visible = false;
            estadoCivil.Visible = false;
            labelEstadoCivil.Visible = false;

            switch (retorno)
            {
                case 1:
                    cantFamiliares.Visible = true;
                    labelFamiliares.Visible = true;
                    estadoCivil.Visible = true;
                    labelEstadoCivil.Visible = true;
                    break;
                case 2:
                    estadoCivil.Visible = true;
                    labelEstadoCivil.Visible = true;
                    estadoCivil.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private int tipoAfiliado(int numeroAfiliado)
        {
            return numeroAfiliado % 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
