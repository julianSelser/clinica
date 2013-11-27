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

namespace Clinica_Frba.Pedir_Turno
{
    public partial class SeleccionarTimeslot : Form
    {

        Form padre;
        DateTime fechaAgenda;
        Profesional profesional;

        internal SeleccionarTimeslot(Form _padre, Profesional _profesional, DateTime _fechaAgenda)
        {
            InitializeComponent();
            this.padre = _padre;
            this.fechaAgenda = _fechaAgenda;
            this.profesional = _profesional;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaTimeslots, AppPedirTurno.traerTimeslotsFecha(profesional, fechaAgenda));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
