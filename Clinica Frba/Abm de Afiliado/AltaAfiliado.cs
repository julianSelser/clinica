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

//Ventana que da alta un afiliado, 
//dependiendo del tipo de afiliado (titular, conyuge, familiar) 
//se inicializa con distintos campos

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class AltaAfiliado : Form
    {
        private Form padre;
        public char sexo;
        public int cantidadFamiliares;
        public string modo;
        private Afiliado afiliado;
        public int nroTitular;

        public AltaAfiliado(ModoAfiliado modoAfiliado,Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.modo = modoAfiliado.modo;
            this.nroTitular = 0;
            fechaNacimiento.Value = Globales.getFechaSistema();

            if (modo == "Familiar" || modo == "Casado/a" || modo == "Concubinato")
            {
                labelEstadoCivil.Visible = false;
                labelFamiliares.Visible = false;
                estadoCivil.Visible = false;
                cantFamiliares.Visible = false;
                this.nroTitular = modoAfiliado.nroAfiliado;

                if (modo == "Casado/a" || modo == "Concubinato")
                {
                    labelEstadoCivil.Visible = true;
                    this.cantidadFamiliares = 0;
                    estadoCivil.Visible = true;
                    estadoCivil.Text = modo;
                    estadoCivil.Enabled = false;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void sexoButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sexoButton1.Checked)
                sexo = 'M';
            else
                sexo = 'F';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            afiliado = crearAfiliado();
            switch (modo)
            {
                case "Titular":
                    AppAfiliado.altaAfiliadoTitular(afiliado);
                    break;
                case "Familiar":
                    AppAfiliado.altaAfiliadoFamiliar(afiliado);
                    break;
                default:
                    AppAfiliado.altaAfiliadoConyuge(afiliado);
                    break;
            }
            MessageBox.Show("El alta se ha realizado correctamente.");
            altasOpcionales();
        }

        private void altasOpcionales()
        {
            if (afiliado.estadoCivil == "Concubinato" || afiliado.estadoCivil == "Casado/a" || afiliado.cantFamiliaresACargo > 0)
            {
                AsistenteVistas.mostrarNuevaVentana(new PeticionAlta(afiliado, padre), this);
            }
            else
            {
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
        }

        private Afiliado crearAfiliado()
        {
            Afiliado afiliado = new Afiliado();
            afiliado.nroAfiliado = nroTitular;
            afiliado.nombre = nombre.Text;
            afiliado.apellido = apellido.Text;
            afiliado.sexo = sexo;
            afiliado.tipoDoc = tipoDoc.Text;
            afiliado.nroDoc = Convert.ToInt32(nroDoc.Text);
            afiliado.direccion = direccion.Text;
            afiliado.mail = mail.Text;
            afiliado.telefono = Convert.ToInt32(telefono.Text);
            afiliado.fechaNac = Convert.ToDateTime(fechaNacimiento.Value);
            afiliado.codPlan = Convert.ToInt32(planMedico.Text);
            afiliado.estadoCivil = estadoCivil.Text;
            afiliado.cantFamiliaresACargo = Convert.ToInt32(cantFamiliares.Text);
            return afiliado;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            inicializarVariables();
            nombre.Clear();
            apellido.Clear();
            sexoButton1.Checked = false;
            sexoButton2.Checked = false;
            direccion.Clear();
            fechaNacimiento.Value = Globales.getFechaSistema();
            tipoDoc.SelectedIndex = -1;
            nroDoc.Clear();
            mail.Clear();
            estadoCivil.SelectedIndex = -1;
            cantFamiliares.Clear();
            planMedico.SelectedIndex = -1;
            telefono.Clear();
        }

        private void inicializarVariables()
        {
            sexo = ' ';
            nroTitular = 0;
            cantidadFamiliares = 0;
        }
    }
}
