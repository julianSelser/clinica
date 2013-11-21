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


//Funcionalidad que permite registrar el diagnostico de la atencion medica por parte del profesional
//una vez realizada la consulta, ingresa sintomas y enfermedades del mismo si las hubiere.
//Permite hacer modificaciones del diagnostico si se desea, en este caso, carga en los textbox
//el diagnostico que ya tenian anteriormente.
//Si no fue registrado nada todavia, los campos estaran en blanco

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
            nroTurnoBox.Text = consulta.idConsulta.ToString();
            if (consulta.enfermedades != "no registrado aún") enfermedadesBox.Text = consulta.enfermedades; //si los campos ya tenian un diagnostico previo, permite editarlos, cargando primero lo que ya tenian en el textbox
            if (consulta.sintomas != "no registrado aún") sintomasBox.Text = consulta.sintomas;
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
            consulta.enfermedades = enfermedadesBox.Text.ToString();
            consulta.sintomas = sintomasBox.Text.ToString();
            AppRegistrarResultado.registrarResultado(consulta);
            MessageBox.Show("El registro de resultado de atención se ha realizado con éxito");
            AsistenteVistas.volverAPadreYCerrar((padre as ListadoConsultas).padre, this);
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
