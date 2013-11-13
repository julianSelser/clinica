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

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ModificarProfesional : Form
    {
        private Form padre;
        Profesional profesional;
        List<EspecialidadMedica> especialidades;

        internal ModificarProfesional(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
            cargarCampos();
            validarCampos();

        }

        private void cargarCampos()
        {
            idBox.Text = profesional.id.ToString();
            direcBox.Text = profesional.direccion;
            telBox.Text = profesional.telefono.ToString();
            mailBox.Text = profesional.mail;
            cargarEspecialidades();
        }

        private void cargarEspecialidades()
        {
            especialidades = AppProfesional.getEspecialidades();
            foreach (EspecialidadMedica especialidad in especialidades)
            {
                especialidadesCheckedListBox.Items.Add(especialidad.descripcion);
            }    
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Dirección", direcBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Teléfono", telBox.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Mail", mailBox.Text, false, Controlador.TipoValidacion.Alfanumerico));
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
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
    }
}
