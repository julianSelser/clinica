using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Domain;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Registro_Resultado_Atencion
{
    public partial class RegistrarDiagnostico : Form
    {
        Form padre;
        ConsultaMedica consulta;

        internal RegistrarDiagnostico(Form padre, ConsultaMedica consulta)
        {
            InitializeComponent();
            this.padre = padre;
            this.consulta = consulta;
            nroTurnoBox.Text = consulta.idTurno.ToString();
            validarCampos();
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Enfermedades", enfermedadesBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Sintomas", sintomasBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            try
            {
                Controlador.validarCampos(campos);
                aceptarButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                aceptarButton.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            sintomasBox.Clear();
            enfermedadesBox.Clear();
        }

        private void sintomasBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void enfermedadesBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

    }
}
