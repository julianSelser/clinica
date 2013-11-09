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

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        private Form padre;
        private Afiliado afiliado;

        internal ModificarAfiliado(Form padre, Afiliado afiliado)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            habilitarBotonesSegunTipo();
            rellenarCampos();
            
        }

        private void rellenarCampos() //TODO: crear procedure que traiga los planes disponibles
        {
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
            direcBox.Text = afiliado.direccion;
        }

        private void habilitarBotonesSegunTipo()
        {
            int retorno = tipoAfiliado(afiliado);

            cantFamiliaresBox.Visible = false;
            labelFamiliares.Visible = false;
            estadoCivilBox.Visible = false;
            labelEstadoCivil.Visible = false;

            switch (retorno)
            {
                case 1:
                    cantFamiliaresBox.Visible = true;
                    labelFamiliares.Visible = true;
                    estadoCivilBox.Visible = true;
                    labelEstadoCivil.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private int tipoAfiliado(Afiliado afiliado)
        {
            return afiliado.nroAfiliado % 100;
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
