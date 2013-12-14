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
using System.Threading;
using System.Globalization;
using Clinica_Frba.AppModel.Excepciones;

//Funcionalidad que permite dar de alta un turno por parte del afiliado con el profesional que desea atenderse,
//eligiendo una fecha de atencion actual o futura disponible, segun la fecha del archivo de configuracion

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        Form padre;
        Profesional profesional;
        Afiliado afiliado;
        EspecialidadMedica especialidadTurno;

        internal PedirTurno(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            if (UsuarioLogeado.Instance.Rol.nombre == "Afiliado")
            {
                setearAfiliado(UsuarioLogeado.Instance.Persona as Afiliado);
                selectAfiliadoButton.Visible = false;
            }
            aceptarButton.Enabled = false;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES", true);
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }


        internal void setearAfiliado(Afiliado afiliado)
        {
            this.afiliado = afiliado;
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
            validarCampos();
        }

        internal void setearProfesional(Profesional profesional, EspecialidadMedica especialidad)
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
            this.especialidadTurno = especialidad;
            especialidadBox.Text = especialidad.descripcion;
            validarCampos();
        }

        private void selectAfiliadoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Pedir Turno"), this);
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Pedir Turno"), this);
        }

        private void validarCampos()
        {
            if (nroAfiliadoBox.Text != "" && profesionalBox.Text != "")
            {
                cargarComboFecha();
            }
            else
            {
                comboFechas.Enabled = false;
                comboFechas.Items.Clear();
                comboTimeslots.Enabled = false;
                comboTimeslots.Items.Clear();
                aceptarButton.Enabled = false;
            }
        }

        private void cargarComboFecha()
        {
            try
            {
                comboFechas.Items.Clear();
                List<DateTime> fechas = AppPedirTurno.traerFechasAgenda(profesional);
                foreach (DateTime fecha in fechas)
                {
                    comboFechas.Items.Add(fecha.ToString("dd/MM/yyyy"));
                }
                comboFechas.Enabled = true;
                comboTimeslots.Enabled = false;
                comboTimeslots.Items.Clear();
                aceptarButton.Enabled = false;
            }
            catch(NoHayHorarioDisponiblesException ex)
            {
                ErrorManager.messageWarningBox(ex, "Pedir Turno");
            }       
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.Instance.Rol.nombre != "Afiliado")
            {
                nroAfiliadoBox.Text = "";
                afiliado = null;
            }
            profesionalBox.Text = "";
            profesional = null;
            comboFechas.Enabled = false;
            comboFechas.Items.Clear();
            comboTimeslots.Enabled = false;
            comboTimeslots.Items.Clear();
            aceptarButton.Enabled = false;
            especialidadBox.Clear();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_horario = crearFechaHorario();
                AppPedirTurno.generarTurno(afiliado, profesional, especialidadTurno, fecha_horario);
                MessageBox.Show("El turno se generó correctamente\n\nNro. Afiliado: " + afiliado.nroAfiliado + "\nId Medico: " + profesional.id + "\nEspecialidad: " + especialidadTurno.descripcion + "\nFecha y Horario: " + fecha_horario.ToString("dd/MM/yy HH:mm"));
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (AfiliadoYaTieneTurnoException ex)
            {
                ErrorManager.messageErrorBox(ex, "Pedir Turno");
            }
        }

        private DateTime crearFechaHorario()
        {
            DateTime fecha = Convert.ToDateTime(comboFechas.Text);
            DateTime horario = Convert.ToDateTime(comboTimeslots.Text);
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, horario.Hour, horario.Minute, 0);
        }

        private void comboFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFechas.SelectedIndex != -1) habilitarComboTimeslots();
        }

        private void habilitarComboTimeslots()
        {
            comboTimeslots.Items.Clear();
            List<DateTime> horarios = AppPedirTurno.traerTimeslotsFecha(profesional, Convert.ToDateTime(comboFechas.Text));
            foreach (DateTime horario in horarios)
                {
                     comboTimeslots.Items.Add(horario.ToString("HH:mm"));
                }
            comboTimeslots.Enabled = true;  
        }

        private void comboTimeslots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTimeslots.SelectedIndex != -1)
            {
                aceptarButton.Enabled = true;
            }
            else
            {
                aceptarButton.Enabled = false;
            }
        }

    }
}
