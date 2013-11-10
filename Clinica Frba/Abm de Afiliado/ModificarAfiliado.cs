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
            telBox.Text = afiliado.telefono.ToString();
            mailBox.Text = afiliado.mail;
            planMedicoBox.Text = afiliado.codPlan.ToString();
            estadoCivilBox.Text = afiliado.estadoCivil;
            cantFamiliaresBox.Text = afiliado.cantFamiliaresACargo.ToString();
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
        {//TODO: agregar validacion de campos
            actualizarAfiliado();
            AppAfiliado.actualizarAfiliado(afiliado);
            MessageBox.Show("La actualización se ha realizado con éxito");
            (padre as IListado).cargarGrilla();
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void actualizarAfiliado()
        {
            afiliado.direccion = direcBox.Text;
            afiliado.telefono = Convert.ToInt32(telBox.Text); 
            afiliado.mail = mailBox.Text;
            afiliado.codPlan = Convert.ToInt32(planMedicoBox.Text);
            afiliado.estadoCivil = estadoCivilBox.Text;
            afiliado.cantFamiliaresACargo = Convert.ToInt32(cantFamiliaresBox.Text);
        }

    }
}
