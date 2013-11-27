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
           
            
            if (!(((RegistrarAgenda) padre).validarRangoHorario(arg_desde, arg_hasta)))
            {
                MessageBox.Show("Debe ingresar un rango horario válido.", "Error");
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

            ((RegistrarAgenda)padre).poblarDiasAtencion(this.id_medico);
            AsistenteVistas.volverAPadreYCerrar(padre, this);

        }

      
    }
}
