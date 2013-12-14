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

//Funcionalidad utilizada por un administrativo para registrar la llegada de un
//paciente a la clínica y efectivizar su turno con un especialista para convertirse en una
//consulta médica.
//En caso de llegar un segundo mas tarde de la hora estipulada del turno, la atencion se cancela.
//La grilla debe mostrar solo para cuando:
//-se selecciona un profesional, muestra todos los turnos del dia que tiene el profesional
//-se selecciona un profesional y afiliado, para confirmar el turno entre profesional y afiliado en el dia

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class RegistroLlegada : Form
    {
        public Form padre;
        Profesional profesional;
        Afiliado afiliado;

        internal RegistroLlegada(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            afiliado = new Afiliado();
            afiliado.nroAfiliado = 0;
            validarCampos();
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Afiliado", nroAfiliadoBox.Text, false, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Profesional", profesionalBox.Text, true, Controlador.TipoValidacion.Codigo));
            try
            {
                Controlador.validarCampos(campos);
                cargarGrilla();
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                grillaTurnos.DataSource = null;
            }
        }

        private void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaTurnos, AppRegistrarLlegada.traerTurnosAfiliadoMedico(afiliado, profesional));
            cargarBotonFuncionalidad();
        }

        private void cargarBotonFuncionalidad()
        {
            if (afiliado.nroAfiliado != 0 && !grillaTurnos.Columns.Contains("Seleccionar"))
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.Text = "Registrar Llegada";
                col.Name = "Seleccionar";
                col.UseColumnTextForButtonValue = true;
                grillaTurnos.Columns.Add(col);
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
        }

        internal void setearProfesional(Profesional profesional)
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
        }

        private void selectAfiliadoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Registrar Llegada"), this);
            validarCampos();
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Registrar Llegada"), this);
            validarCampos();
        }

        private void profesionalBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void nroAfiliadoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void grillaTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(afiliado.nroAfiliado != 0)
            {
                if (e.ColumnIndex == grillaTurnos.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaTurnos.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
                {
                    Turno turno = armarTurno(e.RowIndex);
                    AsistenteVistas.mostrarNuevaVentana(new ElegirBonoConsulta(this, turno), this);
                }
            }
        }

        private Turno armarTurno(int fila)
        {
            Turno turno = new Turno();
            int index = grillaTurnos.Columns["Nro. de Turno"].Index;
            turno.numero = Convert.ToInt32(grillaTurnos.Rows.SharedRow(fila).Cells[index].Value.ToString());
            turno.nroAfiliado = afiliado.nroAfiliado;
            turno.idMedico = profesional.id;
            index = grillaTurnos.Columns["Fecha de Turno"].Index;
            turno.fecha = Convert.ToDateTime(grillaTurnos.Rows.SharedRow(fila).Cells[index].Value);
            return turno;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            nroAfiliadoBox.Clear();
            profesionalBox.Clear();
            profesional = null;
            afiliado.nroAfiliado = 0;
            grillaTurnos.DataSource = null;
            grillaTurnos.Columns.Clear();
            validarCampos();
        }

    }
}
