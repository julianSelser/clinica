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

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class RegistrarAgenda : Form
    {
        private Form padre;


        public RegistrarAgenda(Form padre)
        {

            InitializeComponent();
            this.padre = padre;

            var usuario = UsuarioLogeado.Instance;

            if (usuario.Rol.nombre.Equals("Profesional"))
            {
                Profesional medico = (Profesional) UsuarioLogeado.Instance.Persona;
                labNroMedico.Text = medico.id.ToString();
                cargarPantallaConLosDatos(Convert.ToDecimal(medico.id.ToString()));
                botonQuitarMedico.Visible = false;
            }

            

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

            labNroMedico.Text = textBox1.Text;
            cargarPantallaConLosDatos(id_medico);

        }

        private void cargarPantallaConLosDatos(decimal id_medico)
        {
            //visibilidad
            botonBuscarMedico.Visible = false;
            botonQuitarMedico.Visible = true;


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

            panelLunes.Visible = panelMartes.Visible = panelMiercoles.Visible = panelJueves.Visible = panelViernes.Visible = panelSabado.Visible = false;
            labLuNo.Visible = labMaNo.Visible = labMiNo.Visible = labJuNo.Visible = labViNo.Visible = labSaNo.Visible = true;

            foreach (DataRow dia in dias_atencion.Rows)
            {
                switch (dia["Nombre_Dia"].ToString())
                {

                    case "Lunes":
                        labLuNo.Visible = false;
                        panelLunes.Visible = true;
                        labLuD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labLuH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        break;
                    case "Martes":
                        labMaNo.Visible = false;
                        panelMartes.Visible = true;
                        labMaD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labMaH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        break;
                    case "Miércoles":
                        panelMiercoles.Visible = true;
                        labMiD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labMiH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        labMiNo.Visible = false;
                        break;
                    case "Jueves":
                        panelJueves.Visible = true;
                        labJuD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labJuH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        labJuNo.Visible = false;
                        break;
                    case "Viernes":
                        panelViernes.Visible = true;
                        labViD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labViH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        labViNo.Visible = false;
                        break;
                    case "Sábado":
                        panelSabado.Visible = true;
                        labSaD.Text = DateTime.Parse(dia["Hora_Desde"].ToString()).ToString("HH:mm");
                        labSaH.Text = DateTime.Parse(dia["Hora_Hasta"].ToString()).ToString("HH:mm");
                        labSaNo.Visible = false;
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

        private void confirmarQuitarDia(string nombre_dia)
        {
            if (MessageBox.Show("¿Está seguro? Todos sus turnos para ese día serán cancelados.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                ConectorSQL.ejecutarProcedure("quitarDiaAtencion", (Convert.ToDecimal(labNroMedico.Text)), nombre_dia);
                poblarDiasAtencion(Convert.ToDecimal(labNroMedico.Text));
                MessageBox.Show("Se quitó el día de atención.", "Éxito");
            }

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void botDelLu_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Lunes");
        }

        private void botDelMa_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Martes");
        }

        private void botDelMi_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Miércoles");
        }

        private void botDelJu_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Jueves");
        }

        private void botDelVi_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Viernes");
        }

        private void botDelSa_Click(object sender, EventArgs e)
        {
            confirmarQuitarDia("Sábado");
        }

    }
}
