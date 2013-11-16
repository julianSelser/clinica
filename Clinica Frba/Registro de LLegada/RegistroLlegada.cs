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

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class RegistroLlegada : Form
    {
        private Form padre;
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
            if (e.ColumnIndex == grillaTurnos.Columns["Seleccionar"].Index && e.RowIndex >= 0) //Para que la accion de click sea valida solo sobre el boton
            {
                Turno turno = new Turno();
                AsistenteVistas.mostrarNuevaVentana(new ElegirBonoConsulta(this, turno), this);
            }
        }

    }
}
