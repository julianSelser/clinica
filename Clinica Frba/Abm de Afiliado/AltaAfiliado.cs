﻿using System;
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
//ciertos campos se habilitan o no

//Una vez dado de alta el titular se 
//da la opcion de dar de alta al conyuge o familiares si los tuviere.
//En caso de no darlos de alta en este momento, se debe ir a modificar el afiliado titular
//para volver a tener la opcion

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class AltaAfiliado : Form
    {
        private Form padre;
        public char sexo;  //TODO: agregar validaciones (tipo de dato de campos de la vista; campos obligatorios no completos, marcarlos con asterisco rojo cuales)
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
            aceptarButton.Enabled = false;
            sexoButton1.Checked = true;
            sexoButton2.Checked = false;

            if (modo == "Familiar" || modo == "Casado/a" || modo == "Concubinato")
            {
                labelEstadoCivil.Visible = false;
                labelFamiliares.Visible = false;
                estadoCivil.Visible = false;
                estadoCivil.Text = "-";
                cantFamiliares.Visible = false;
                cantFamiliares.Text = "0";
                this.nroTitular = modoAfiliado.nroAfiliado;

                if (modo == "Casado/a" || modo == "Concubinato")
                {
                    labelEstadoCivil.Visible = true;
                    estadoCivil.Visible = true;
                    estadoCivil.Text = modo;
                    estadoCivil.Enabled = false;
                }
            }
            validarCampos();
        }
        
        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", nombre.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Apellido", apellido.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Tipo Documento", tipoDoc.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Numero Documento", nroDoc.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Dirección", direccion.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Teléfono", telefono.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Plan Médico", planMedico.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Mail", mail.Text, false, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Estado Civil", estadoCivil.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Cantidad de familiares a cargo", cantFamiliares.Text, false, Controlador.TipoValidacion.Codigo));
            try
            {
                Controlador.validarCampos(campos);
                aceptarButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion vEx)
            {
                errorBox.Text = vEx.mensaje;
                aceptarButton.Enabled = false;
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

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            if(cantFamiliares.Text == "")cantFamiliares.Text = "0";
            afiliado = crearAfiliado();
            switch (modo)
            {
                case "Titular": //TODO: Agregar validaciones de existencia (nombre-apellido-tipoDoc-nroDoc ya existe)
                    AppAfiliado.altaAfiliadoTitular(afiliado);
                    break;
                case "Familiar":
                    AppAfiliado.altaAfiliadoFamiliar(afiliado);
                    break;
                default: 
                    AppAfiliado.altaAfiliadoConyuge(afiliado);
                    break;
            }

            afiliado.nroAfiliado = AppAfiliado.buscarNroAfiliado(afiliado);
            MessageBox.Show("El alta del afiliado Nro. "+ afiliado.nroAfiliado +" se ha realizado correctamente.");

            if (modo == "Concubinato" || modo == "Casado/a")
            {
                (padre as IPeticionAlta).deshabilitarConyuge();
            }

            if (modo == "Familiar")
            {
                (padre as IPeticionAlta).decrementarCantFamiliares();
            }

            if (modo == "Titular")
            {
                altasOpcionales();
            }
            else
            {
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
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
            sexoButton1.Checked = true;
            sexoButton2.Checked = false;
            direccion.Clear();
            fechaNacimiento.Value = Globales.getFechaSistema();
            tipoDoc.SelectedIndex = -1;
            nroDoc.Clear();
            mail.Clear();
            if (modo == "Titular")
            {
                estadoCivil.SelectedIndex = -1;
                cantFamiliares.Clear();
            }
            planMedico.SelectedIndex = -1;
            telefono.Clear();
        }

        private void inicializarVariables()
        {
            sexo = 'M';
            cantidadFamiliares = 0;
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void nroDoc_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void mail_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cantFamiliares_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void planMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void estadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

    }
}
