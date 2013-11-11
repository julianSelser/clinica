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

        internal ModificarProfesional(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
           // cargarCampos(AppProfesional.traerUnMedico(padre.TextotextId));

        }

        private void cargarCampos(Profesional medico)
        {
            for (int x = 1; x <= 20; x++)
            {
                checkedListBox1.Items.Add("Especialidad " + x.ToString());
            }
            nombre.Text = medico.nombre;
            apellido.Text = medico.apellido;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
  
    }
}
