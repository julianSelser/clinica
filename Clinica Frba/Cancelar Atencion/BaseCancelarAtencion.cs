using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

// template principal de las tres ventanas que deben verse al solicitarse una cancelacion de turno
// define el comportamiento comun que debe haber para las ventanas de cancelacion ya sea de medico, profesional o admin
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class BaseCancelarAtencion : Form
    {
        protected Form padre;

        public BaseCancelarAtencion(){ InitializeComponent(); }

        public BaseCancelarAtencion(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        //metodos a implementar en las subclases
        virtual protected bool camposValidos() { return true; }
        virtual protected DataTable llenarGrilla() { return null; }
        virtual protected bool fechasValidas() { return true; }

        protected void buscar_Click(object sender, EventArgs e)
        {
            this.ActualizarGrilla();
        }

        protected void cancelarPeriodo_Click(object sender, EventArgs e)
        {
            if (fechasValidas())
            {
                AsistenteVistas.mostrarNuevaVentana(new SetMotivoCancelarPeriodo(this, (DataTable)grilla.DataSource), this);
            }
            else MessageBox.Show("Debe ingresar un periodo", "Error de ingreso"
                                 , MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        protected void cancelarAtencion_Click(object sender, EventArgs e)
        {
            if (0 != grilla.SelectedRows.Count)
            {
                AsistenteVistas.mostrarNuevaVentana(new SetearMotivoCancelacion(this, grilla.SelectedRows), this);
            }
            else MessageBox.Show("Debe Seleccionar una fila", "Error de ingreso"
                                 , MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        virtual protected string mensajeDeError() 
        {
            return "Asegurese de estar ingresando el nombre y el apellido y que el DNI esté completo.";
        }

        public void ActualizarGrilla()
        {
            if (camposValidos()) //cada subclase debe indicar como validar los campos ingresados
            {
                grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                grilla.DataSource = llenarGrilla(); //cada subclase debe indicar como llenar su grilla

                grilla.AutoResizeColumns();
            }
            else
                MessageBox.Show(mensajeDeError(), "Error de ingreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }


        /********************************************************************************************************************
        *                                                VALIDACIONES                                                       *
        * ******************************************************************************************************************/

        //separar nombre y apellido, ojo, no chequea la integridad de las cadenas, eso se hace desde afuera
        public string[] separarNombreYApellido(string nombreYapellido)
        {
            return nombreYapellido.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        //valida si las cadenas de busqueda son validas (no nulas y no espacios)
        public bool cadenasBusquedaValidas(string nombreYapellido, string nroDocumento)
        {
            return  Controlador.cadenaEsNumerica(nroDocumento)
                && !Controlador.cadenaEsVaciaONull(nombreYapellido)
                && Controlador.tieneNombreYAPellido(nombreYapellido);
        }

        //valida un intervalo de fechas ingresadas por textbox
        public bool fechasValidas(string desde, string hasta)
        {
            DateTime? desdeDT;
            DateTime? hastaDT;

            try // no lo hago con tryParse por que solo quiere catchear FormatException
            {
                desdeDT = Controlador.parsear(desde);
                hastaDT = Controlador.parsear(hasta);
            }
            catch (FormatException)
            {
                return false;
            }
            return hastaDT > desdeDT || hastaDT == null && desdeDT == null ? true : false;
        }
    }
}