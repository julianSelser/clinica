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
    public partial class AltaAfiliado : Form
    {
        private Form padre;
        public char sexo;
        public int cantidadFamiliares;
        public string modo;

        public AltaAfiliado(string modo,Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            altaConyuge.Visible = false;
            altaFamiliar.Visible = false;
            this.modo = modo;

            if (modo == "Familiar" || modo == "Casado/a" || modo == "Concubinato")
            {
                labelEstadoCivil.Visible = false;
                labelFamiliares.Visible = false;
                estadoCivil.Visible = false;
                cantFamiliares.Visible = false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void altaConyuge_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado(estadoCivil.Text, this), this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                sexo = 'M';
            else
                sexo = 'F';
        }

        private void estadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(modo == "Titular")
            {
                if (estadoCivil.Text == "Casado/a" || estadoCivil.Text == "Concubinato") altaConyuge.Visible = true;
               else altaConyuge.Visible = false;
            }
        }

        private void cantFamiliares_TextChanged(object sender, EventArgs e)
        {
            cantidadFamiliares = Convert.ToInt32(cantFamiliares.Text);
            if (cantidadFamiliares > 0)
            {
                altaFamiliar.Visible = true;
            }
        }

        private void altaFamiliar_Click(object sender, EventArgs e)
        {
            cantFamiliares.Enabled = false;
            if (cantidadFamiliares > 0)
            {
                AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado("Familiar", this), this);
            }
            else
            {
                altaFamiliar.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modo != "Titular")
            {
                AltaAfiliado padre1 = (AltaAfiliado)padre;

                if (modo == "Familiar")
                {
                    padre1.decrementarFamiliar();
                }
                if (modo == "Casado/a" || modo == "Concubinato")
                {
                    padre1.deshabilitarAltaConyuge();
                }
            }
            Afiliado afiliado = crearAfiliado();
            AppAfiliado.altaAfiliado(afiliado);
            MessageBox.Show("El alta se ha realizado correctamente.");
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        public void decrementarFamiliar()
        {
            cantidadFamiliares--;
            if (cantidadFamiliares == 0) altaFamiliar.Visible = false;
        }

        public void deshabilitarAltaConyuge()
        {
            estadoCivil.Enabled = false;
            altaConyuge.Visible = false;
        }

        private Afiliado crearAfiliado()
        {
            Afiliado afiliado = new Afiliado();
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
    }
}
