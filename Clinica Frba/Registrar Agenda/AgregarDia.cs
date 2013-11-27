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
    public partial class AgregarDia : Form
    {
        private Form padre;
        private decimal id_medico;

        public AgregarDia(Form padre, decimal id_medico)
        {
            InitializeComponent();
            this.padre = padre;
            this.id_medico = id_medico;
        }

        private void AgregarDia_Load(object sender, EventArgs e)
        {
            comboDia.SelectedItem = "Lunes";
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void comboDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDia.SelectedItem.ToString() == "Sábado")
            {
                comboDesde.Visible = comboHasta.Visible = false;
                comboSabDesde.Visible = comboSabHasta.Visible = true;

                comboSabDesde.SelectedItem = "10:00";
                comboSabHasta.SelectedItem = "14:00";
                //valores default
            }

            else
            {
                comboDesde.Visible = comboHasta.Visible = true;
                comboSabDesde.Visible = comboSabHasta.Visible = false;

                comboDesde.SelectedItem = "09:00";
                comboHasta.SelectedItem = "17:00";
                //valores default
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            string arg_desde;
            string arg_hasta;

            //me fijo que el rango horario no sea ni negativo ni nulo
            if (comboDia.SelectedItem.ToString() == "Sábado")
            {
                arg_desde = comboSabDesde.SelectedItem.ToString();
                arg_hasta = comboSabHasta.SelectedItem.ToString();
            }
            else
            {
                arg_desde = comboDesde.SelectedItem.ToString();
                arg_hasta = comboHasta.SelectedItem.ToString();
            }


            if (!(((RegistrarAgenda)padre).validarRangoHorario(arg_desde, arg_hasta)))
            {
                MessageBox.Show("Debe ingresar un rango horario válido.", "Error");
                return;
            }

            try
            {
                ConectorSQL.ejecutarProcedure("agregarDiaAtencion", this.id_medico, comboDia.SelectedItem.ToString(), arg_desde, arg_hasta);
            }

            catch
            {
                MessageBox.Show("No se pudo agregar el día de atención. Verifique que no haya un horario ya existente para este día de la semana, y tenga en cuenta que un médico sólo puede trabajar hasta 48 hs semanales.", "Error");
                return;
            }


            ((RegistrarAgenda)padre).poblarDiasAtencion(this.id_medico);
            AsistenteVistas.volverAPadreYCerrar(padre, this);

        }

    }
}
