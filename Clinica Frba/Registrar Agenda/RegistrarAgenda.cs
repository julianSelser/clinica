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

        private void RegistrarAgenda_Load(object sender, EventArgs e)
        {
            if (labNroMedico.Visible) poblarDiasAtencion(Convert.ToDecimal(labNroMedico.Text));
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

        //público porque las subventanitas que saltan también tienen que actualizar estos datos
        public void poblarDiasAtencion(decimal id_medico)
        {
            DataTable dias_atencion;
            DataTable datos_medico;

            datos_medico = ConectorSQL.traerDataTable("getNYAMedico", id_medico);
            dias_atencion = ConectorSQL.traerDataTable("getDiasAtencion", id_medico);

            panelLunes.Visible = panelMartes.Visible = panelMiercoles.Visible = panelJueves.Visible = panelViernes.Visible = panelSabado.Visible = false;
            labLuNo.Visible = labMaNo.Visible = labMiNo.Visible = labJuNo.Visible = labViNo.Visible = labSaNo.Visible = true;

            labNombreMedico.Visible = true;
            labNombreMedico.Text = datos_medico.Rows[0]["Nombre"].ToString() + " " + datos_medico.Rows[0]["Apellido"].ToString();

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

            labNombreMedico.Visible = labNroMedico.Visible = false;
            textBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void confirmarQuitarDia(string nombre_dia)
        //esto se llama confirmar pero no pide confirmación de nada, es para evitar un refactor
        {
            ConectorSQL.ejecutarProcedure("quitarDiaAtencion", (Convert.ToDecimal(labNroMedico.Text)), nombre_dia);
            poblarDiasAtencion(Convert.ToDecimal(labNroMedico.Text));
            

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

  
       

        private void botModLu_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Lunes", labLuD.Text, labLuH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botModMa_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Martes", labMaD.Text, labMaH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botModMi_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Miércoles", labMiD.Text, labMiH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botModJu_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Jueves", labJuD.Text, labJuH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botModVi_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Viernes", labViD.Text, labViH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botModSa_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarDia(this, "Sábado", labSaD.Text, labSaH.Text, Convert.ToDecimal(labNroMedico.Text)), this);
        }

        private void botAddDia_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AgregarDia(this, Convert.ToDecimal(labNroMedico.Text)), this);
        }


        public bool validarRangoHorario(string desde, string hasta)
        //esto lo pongo acá porque lo van a necesitar dos de los subforms
        {
            int hsdesde;
            int hshasta;
            int mindesde;
            int minhasta;

            hsdesde = Convert.ToInt16(desde.Substring(0, 2));
            hshasta = Convert.ToInt16(hasta.Substring(0, 2));

            mindesde = Convert.ToInt16(desde.Substring(3, 2));
            minhasta = Convert.ToInt16(hasta.Substring(3, 2));

            if (hsdesde > hshasta) return false;
            if (hsdesde == hshasta)
            {
                if (mindesde < minhasta) return true;
                else return false;
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new CargarPeriodo(this, Convert.ToDecimal(labNroMedico.Text)), this);
        }

    }
}
