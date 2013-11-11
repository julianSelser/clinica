using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class RegistrarAgenda : Form
    {
        private Form padre;

        public RegistrarAgenda(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void botonBuscarMedico_Click(object sender, EventArgs e)
        {
            decimal id_medico;
            int existe;

            if (textBox1.Text.Length > 18)
            {
                MessageBox.Show("Debe ingresar un ID de profesional válido.", "Error");
                return;
            }

            try
            {
                id_medico = Convert.ToDecimal(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Debe ingresar un ID de profesional válido.", "Error");
                return;
            }

            if (ConectorSQL.ejecutarProcedureWithReturnValue("verifyMedico", id_medico) == 0)
            {
                MessageBox.Show("No se encontró tal médico.", "Error");
                return;
            }




            botonBuscarMedico.Visible = false;
            botonQuitarMedico.Visible = true;

            labNroMedico.Text = textBox1.Text;

            labNroMedico.Visible = true;
            textBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void botonQuitarMedico_Click(object sender, EventArgs e)
        {
            botonBuscarMedico.Visible = true;
            botonQuitarMedico.Visible = false;

            labNroMedico.Text = textBox1.Text;

            labNroMedico.Visible = false;
            textBox1.Visible = true;
            groupBox2.Visible = false;
        }


      
    }
}
