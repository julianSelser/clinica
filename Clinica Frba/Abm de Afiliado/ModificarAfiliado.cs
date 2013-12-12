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
using Clinica_Frba.AppModel.Excepciones;

//Funcionalidad que permite editar los datos del afiliado y luego de confirmarlos, los actualiza en la base de datos

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        private Form padre;
        private Afiliado afiliado;
        List<PlanMedico> planes;
        int planOrigen;

        internal ModificarAfiliado(Form padre, Afiliado afiliado)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            this.planOrigen = afiliado.codPlan;
            habilitarBotonesSegunTipo();
            acceptButton.Enabled = false;
            cargarCombos();
            rellenarCampos();
            validarCampos();    
        }

        private void rellenarCampos()
        {
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
            direcBox.Text = afiliado.direccion;
            telBox.Text = afiliado.telefono.ToString();
            mailBox.Text = afiliado.mail;
            planMedicoBox.Text = getDescripcionPlan(afiliado.codPlan);
            estadoCivilBox.Text = afiliado.estadoCivil;
            cantFamiliaresBox.Text = afiliado.cantFamiliaresACargo.ToString();
        }

        private string getDescripcionPlan(int codigo)
        {
            foreach (PlanMedico plan in planes)
            {
                if (plan.codigo == codigo) return plan.descripcion;
            }
            throw new Exception("Codigo no encuentra correspondiente descripcion de plan medico.\nDetalle: " + codigo.ToString());
        }

        private void cargarCombos()
        {
            planes = AppAfiliado.traerPlanesMedicos();
            foreach (PlanMedico plan in planes)
            {
                planMedicoBox.Items.Add(plan.descripcion);
            }
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
            try
            {
                actualizarAfiliado();
                AppAfiliado.actualizarAfiliado(afiliado);
                MessageBox.Show("La actualización se ha realizado con éxito");
                registrarCambioPlan();
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (DecrementarCantFamiliaresException ex)
            {
                ErrorManager.messageErrorBox(ex, "Modificar Afiliado");
            }
        }

        private void registrarCambioPlan()
        {
            if (afiliado.codPlan != planOrigen)
            {
                DialogConLabeledTextBox dialogMotivo = new DialogConLabeledTextBox("Ingrese el motivo de cambio de plan médico");
                if (dialogMotivo.ShowDialog() == DialogResult.OK)
                {
                    AppAfiliado.registrarCambioPlanMedico(afiliado, planOrigen, dialogMotivo.texto);
                    MessageBox.Show("El registro de cambio de plan médico se ha realizado con éxito");
                }
            }
        }

        private void actualizarAfiliado()
        {
            afiliado.direccion = direcBox.Text;
            afiliado.telefono = Convert.ToInt32(telBox.Text); 
            afiliado.mail = mailBox.Text;
            afiliado.codPlan = getCodigoPlan(planMedicoBox.Text);
            afiliado.estadoCivil = estadoCivilBox.Text;
            if (cantFamiliaresBox.Text == "") cantFamiliaresBox.Text = "0";
            afiliado.cantFamiliaresACargo = Convert.ToInt32(cantFamiliaresBox.Text);
        }

        private int getCodigoPlan(string descripcion)
        {
            foreach (PlanMedico plan in planes)
            {
                if (plan.descripcion == descripcion) return plan.codigo;
            }
            throw new Exception("Descripcion no encuentra correspondiente codigo de plan medico.\nDetalle: " + descripcion);
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Dirección", direcBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Teléfono", telBox.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Plan Médico", planMedicoBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Mail", mailBox.Text, false, Controlador.TipoValidacion.Email));
            campos.Add(new Campo("Estado Civil", estadoCivilBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Cantidad de familiares a cargo", cantFamiliaresBox.Text, false, Controlador.TipoValidacion.Codigo));
            try
            {
                Controlador.validarCampos(campos);
                acceptButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                acceptButton.Enabled = false;
            }
        }

        private void direcBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void telBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void mailBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void planMedicoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void estadoCivilBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cantFamiliaresBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

    }
}
