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

//Funcionalidad que permite registrar el diagnostico de la atencion medica por parte del profesional
//una vez realizada la misma, ingresa sintomas y enfermedades del mismo si las hubiere

namespace Clinica_Frba.Registro_Resultado_Atencion
{
    public partial class RegistroResultadoAtencion : Form
    {
        private Form padre;
        Profesional profesional;
        Afiliado afiliado;

        public RegistroResultadoAtencion(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            fechaAtencionPicker.Text = Globales.getFechaSistema().ToString();
            if (UsuarioLogeado.Instance.Rol.nombre == "Profesional")
            {
                profesionalBox.Text = (UsuarioLogeado.Instance.Persona as Profesional).id.ToString();
                selectProfesionalButton.Hide();
                profesional = (UsuarioLogeado.Instance.Persona as Profesional);
            }
            validarCampos();
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Afiliado", nroAfiliadoBox.Text, true, Controlador.TipoValidacion.Codigo));
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
            AsistenteVistas.cargarGrilla(grillaTurnos, AppRegistrarResultado.traerConsultas(afiliado, profesional, Convert.ToDateTime(fechaAtencionPicker.Text)));
            cargarBotonFuncionalidad();
        }

        private void cargarBotonFuncionalidad()
        {
            if (afiliado.nroAfiliado != 0 && !grillaTurnos.Columns.Contains("Seleccionar"))
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.Text = "Registrar Resultados";
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

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nroAfiliadoBox.Clear();
            if (UsuarioLogeado.Instance.Rol.nombre != "Profesional") profesionalBox.Clear();
            fechaAtencionPicker.Text = Globales.getFechaSistema().ToString();
        }

        private void nroAfiliadoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void profesionalBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void fechaAtencionPicker_ValueChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void grillaTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (afiliado.nroAfiliado != 0)
            {
                if (e.ColumnIndex == grillaTurnos.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaTurnos.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
                {
                    ConsultaMedica consulta = armarConsultaMedica(e.RowIndex);
                    AsistenteVistas.mostrarNuevaVentana(new RegistrarDiagnostico(this, consulta), this);
                }
            }
        }

        private ConsultaMedica armarConsultaMedica(int fila)
        {
            ConsultaMedica consulta = new ConsultaMedica();
            consulta.idTurno = 0;
            return consulta;
        }

        private void selectAfiliadoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Registrar Resultado"), this);
            validarCampos();
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Registrar Resultado"), this);
            validarCampos();
        }

    }
}
