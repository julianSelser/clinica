using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

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

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if (motivoValido(motivoTextBox.Text))
            {
                accionarCancelacion();

                padre.ActualizarGrilla();

                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            else
                MessageBox.Show(Controlador.cadenaEsVaciaONull(motivoTextBox.Text) ? "Debe ingresar un motivo" : "El número de letras es demasiado grande. Abrevie la descripcion.", "Error de ingreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        virtual protected void accionarCancelacion() { }

        public bool motivoValido(string motivo)
        {
            return motivo.Length <= 254 && !Controlador.cadenaEsVaciaONull(motivo);
        }
    }
}
