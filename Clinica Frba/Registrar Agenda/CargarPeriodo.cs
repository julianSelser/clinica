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
    public partial class CargarPeriodo : Form
    {
        private Form padre;
        private decimal id_medico;

        public CargarPeriodo(Form padre, decimal id_medico)
        {
            InitializeComponent();
            this.padre = padre;
            this.id_medico = id_medico;
        }

        private void CargarPeriodo_Load(object sender, EventArgs e)
        {
            DataTable datos_medico;

            datos_medico = ConectorSQL.traerDataTable("getNYAMedico", this.id_medico);
            //nuevamente, por PK, sé que esta DataTable tiene sólo una fila

            labMedico.Text = (datos_medico.Rows[0]["Nombre"].ToString() + " " + datos_medico.Rows[0]["Apellido"].ToString());
            dtpDesde.Value = Globales.getFechaSistema();
            dtpHasta.Value = Globales.getFechaSistema();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private bool verificarRangoNonZero(DateTime desde, DateTime hasta)
        {
            if (desde >= hasta) return false;
            else return true;
        }

        private bool verificarLongitudRango(DateTime desde, DateTime hasta)
        {
            if (hasta.Subtract(desde).TotalDays > 120) return false;
            else return true;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (!(verificarRangoNonZero(dtpDesde.Value, dtpHasta.Value)))
            {
                MessageBox.Show("Debe especificar un rango de fechas válido", "Error");
                return;
            }

            if (dtpDesde.Value < Globales.getFechaSistema())
            {
                MessageBox.Show("No puede registrar una agenda con fecha pasada", "Error");
                return;
            }

            if (!(verificarLongitudRango(dtpDesde.Value, dtpHasta.Value)))
            {
                MessageBox.Show("No se pueden proyectar agendas a más de 120 días", "Error");
                return;
            }

            //pido confirmación
            if (!(MessageBox.Show("¿Está seguro? Una vez registrada, su agenda no podrá modificarse.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                return;
            }


            try
            {
                ConectorSQL.ejecutarProcedure("updateFechasMedico", this.id_medico, dtpDesde.Value, dtpHasta.Value);
                }
            catch
            {
                //queda algo para catchear?
                MessageBox.Show("Error desconocido de la BD", "Error");
                return;
            }
            ConectorSQL.ejecutarProcedure("generarAgenda", this.id_medico, dtpDesde.Value, dtpHasta.Value);
            

            MessageBox.Show("Se generó la agenda profesional", "Éxito");
            ((RegistrarAgenda)padre).cargarPantallaConLosDatos(this.id_medico);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }


    }
}
