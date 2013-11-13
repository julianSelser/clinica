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
            //declaraciones
            decimal id_medico;


            //validaciones
            if (textBox1.Text.Length > 18)
            {
                MessageBox.Show("Debe ingresar un ID de profesional válido.", "Error");
                return;
            }

            try
            {
                Convert.ToUInt64(textBox1.Text); // esto me asegura que no me pongan cosas raras
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

            //visibilidad
            botonBuscarMedico.Visible = false;
            botonQuitarMedico.Visible = true;

            labNroMedico.Text = textBox1.Text;

            labNroMedico.Visible = true;
            textBox1.Visible = false;
            groupBox2.Visible = true;

            //traer datos
            poblarDiasAtencion(id_medico);
            

        }

        private void poblarDiasAtencion(decimal id_medico)
        {
            DataTable dias_atencion;

            dias_atencion = ConectorSQL.traerDataTable("getDiasAtencion", id_medico);

            foreach (DataRow dia in dias_atencion.Rows)
            {
                switch (dia["Nombre_Dia"].ToString())
                {

                    case "Lunes":
                        chkLunes.Checked = true;
                        comboLunesDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboLunesHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        break;
                    case "Martes":
                        chkMartes.Checked = true;
                        comboMartesDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboMartesHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        break;
                    case "Miércoles":
                        comboMiercolesDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboMiercolesHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        chkMiercoles.Checked = true;
                        break;
                    case "Jueves":
                        comboJuevesDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboJuevesHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        chkJueves.Checked = true;
                        break;
                    case "Viernes":
                        comboViernesDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboViernesHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        chkViernes.Checked = true;
                        break;
                    case "Sábado":
                        comboSabadoDesde.SelectedItem = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        comboSabadoHasta.SelectedItem = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        chkSabado.Checked = true;
                        break;
                }
            }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void botonRestore_Click(object sender, EventArgs e)
        {
            decimal ID_Medico;
            ID_Medico = Convert.ToDecimal(labNroMedico.Text);
            poblarDiasAtencion(ID_Medico);
        }

        private void chkLunes_CheckedChanged(object sender, EventArgs e)
        {
            panelLunes.Visible = this.chkLunes.Checked;
        }
        private void chkMartes_CheckedChanged(object sender, EventArgs e)
        {
            panelMartes.Visible = this.chkMartes.Checked;
        }
        private void chkMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            panelMiercoles.Visible = this.chkMiercoles.Checked;
        }
        private void chkJueves_CheckedChanged(object sender, EventArgs e)
        {
            panelJueves.Visible = this.chkJueves.Checked;
        }
        private void chkViernes_CheckedChanged(object sender, EventArgs e)
        {
            panelViernes.Visible = this.chkViernes.Checked;
        }
        private void chkSabado_CheckedChanged(object sender, EventArgs e)
        {
            panelSabado.Visible = this.chkSabado.Checked;
        }
      
    }
}
