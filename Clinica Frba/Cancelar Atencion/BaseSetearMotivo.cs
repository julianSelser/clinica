using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

// base para las ventanas que especifican el motivo
// el comportamiento es casi idéntico para las dos que se necesitan (cancelar periodo o dia)
// asi que se factoriza el comportamiento comun en esta clase
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class BaseSetearMotivo : Form
    {
        protected BaseCancelarAtencion padre;

        public BaseSetearMotivo() { InitializeComponent(); }

        public BaseSetearMotivo(BaseCancelarAtencion padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        //ve si un motivo es valido y actualiza la grilla o informa un error
        protected void aceptar_Click(object sender, EventArgs e)
        {
            if (motivoTextBox.Text.Length <= 254 && !Controlador.cadenaEsVaciaONull(motivoTextBox.Text))
            {
                accionarCancelacion(); //metodo a implementar por las subclases

                padre.ActualizarGrilla();

                MessageBox.Show("La cancelación se realizó correctamente.");
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            else
                MessageBox.Show(Controlador.cadenaEsVaciaONull(motivoTextBox.Text) ? "Debe ingresar un motivo" : "El número de letras es demasiado grande. Abrevie la descripcion.", "Error de ingreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        virtual protected void accionarCancelacion() { } //metodo que deben implementar las subclases
    }
}
