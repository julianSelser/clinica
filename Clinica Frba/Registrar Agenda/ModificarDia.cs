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
    public partial class ModificarDia : Form
    {
        private Form padre;
        private string nombre_dia;
        private string str_desde;
        private string str_hasta;
        private decimal id_medico;

        public ModificarDia(Form padre, string nombre_dia, string str_desde, string str_hasta, decimal id_medico)
        {
            InitializeComponent();
            this.padre = padre;
            this.nombre_dia = nombre_dia;
            this.str_desde = str_desde;
            this.str_hasta = str_hasta;
            this.id_medico = id_medico;
        }

        private void ModificarDia_Load(object sender, EventArgs e)
        {
            this.Text = this.nombre_dia + ": horarios de atención.";
            if (this.nombre_dia == "Sábado")
            {
                comboSabDesde.SelectedItem = str_desde;
                comboSabHasta.SelectedItem = str_hasta;
                comboSabDesde.Visible = true;
                comboSabHasta.Visible = true;
                comboDesde.Visible = false;
                comboHasta.Visible = false;

            }
            else
            {
                comboDesde.SelectedItem = str_desde;
                comboHasta.SelectedItem = str_hasta;
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private bool validarRangoHorario(string desde, string hasta)
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

        private void botAceptar_Click(object sender, EventArgs e)
        {
            string arg_desde;
            string arg_hasta;

            //me fijo que el rango horario no sea ni negativo ni nulo
            if (this.nombre_dia == "Sábado")
            {
                arg_desde = comboSabDesde.SelectedItem.ToString();
                arg_hasta = comboSabHasta.SelectedItem.ToString();
            }
            else
            {
                arg_desde = comboDesde.SelectedItem.ToString();
                arg_hasta = comboHasta.SelectedItem.ToString();
            }
           
            
            if (!(validarRangoHorario(arg_desde, arg_hasta)))
            {
                MessageBox.Show("Debe ingresar un rango horario válido.", "Error");
                return;
            }

            //pido confirmación
            if (!(MessageBox.Show("¿Está seguro? Si usted tiene turnos pendientes fuera del nuevo horario, serán cancelados.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                return;
            }

            //la acción sobre la DB la meto en un bloque try, porque la restricción de las 48 hs semanales va a saltar en la base
            try
            {
                ConectorSQL.ejecutarProcedure("modificarDiaAtencion", this.id_medico, this.nombre_dia, arg_desde, arg_hasta);
            }

            catch
            {
                MessageBox.Show("No se pudo modificar el horario ya que un profesional no puede trabajar más de 48 horas semanales. Por favor revise sus horarios antes de proceder.", "Error");
                return;
            }

            MessageBox.Show("Se actualizaron los horarios para este día.", "Éxito");
            ((RegistrarAgenda)padre).poblarDiasAtencion(this.id_medico);
            AsistenteVistas.volverAPadreYCerrar(padre, this);

        }

      
    }
}
