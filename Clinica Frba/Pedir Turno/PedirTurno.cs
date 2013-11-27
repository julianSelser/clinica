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


//Funcionalidad que permite dar de alta un turno por parte del afiliado con el profesional que desea atenderse

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        Form padre;
        Profesional profesional;
        Afiliado afiliado;
        List<DateTime> fechas;
        List<DateTime> horarios;

        internal PedirTurno(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            if (UsuarioLogeado.Instance.Rol.nombre == "Afiliado")
            {
                setearAfiliado(UsuarioLogeado.Instance.Persona as Afiliado);
                selectAfiliadoButton.Visible = false;
            }
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

        internal void setearProfesional(Profesional profesional)
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
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
            if(nroAfiliadoBox.Text != "" && profesionalBox.Text != "")
            {
                cargarComboFecha();
            }
        }

        private void cargarComboFecha()
        {
            fechas = AppPedirTurno.traerFechasAgenda(profesional);
            foreach (DateTime fecha in fechas)
            {
                comboFechas.Items.Add(fecha.ToString("dd/MM/yyyy"));
            }
            comboFechas.Enabled = true;
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
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            //AppPedirTurno.generarTurno();
        }

        private void comboFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFechas.SelectedIndex != -1) habilitarComboTimeslots();
        }

        private void habilitarComboTimeslots()
        {
            List<DateTime> horarios = AppPedirTurno.traerTimeslotsFecha(profesional,Convert.ToDateTime(comboFechas.Text));
            foreach (DateTime horario in horarios)
            {
                comboTimeslots.Items.Add(horario.ToString("HH:mm"));
            }
            comboTimeslots.Enabled = true;
        }

    }
}
