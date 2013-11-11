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
    public partial class AltaProfesional : Form
    {
        private Form padre;
        private char sexo;
        List<EspecialidadMedica> especialidades;

        public AltaProfesional(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
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

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void masculinoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (masculinoRadioButton.Checked)
                sexo = 'M';
            else
                sexo = 'F';
        }

    }
}
