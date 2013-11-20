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
        public Form padre;
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
            AsistenteVistas.cargarGrilla(grillaTurnos, AppRegistrarResultado.traerConsultas(afiliado, profesional, Convert.ToDateTime(fechaAtencionPicker.Text), checkConsultaSinResultado.Checked ));
            cargarBotonFuncionalidad();
        }

        private void cargarBotonFuncionalidad()
        {
            if (afiliado.nroAfiliado != 0 && !grillaTurnos.Columns.Contains("Seleccionar"))
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.Text = "Resultados";
                col.Name = "Seleccionar";
                col.UseColumnTextForButtonValue = true;
                grillaTurnos.Columns.Add(col);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        internal void setearAfiliado(Afiliado afiliado) //metodos utilizados por otra vista de grilla para setear el atributo afiliado
        {
            this.afiliado = afiliado;
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
        }

        internal void setearProfesional(Profesional profesional) //metodos utilizados por otra vista de grilla para setear el atributo profesional
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            fechaAtencionPicker.Text = Globales.getFechaSistema().ToString();
            nroAfiliadoBox.Clear();
            if (UsuarioLogeado.Instance.Rol.nombre != "Profesional")
            {
                profesionalBox.Clear();
                profesional = null;
            }
            afiliado.nroAfiliado = 0;
            grillaTurnos.DataSource = null;
            grillaTurnos.Columns.Clear();
            validarCampos();
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
            int index = grillaTurnos.Columns["Nro. de consulta"].Index;
            consulta.idConsulta = Convert.ToInt32(grillaTurnos.Rows.SharedRow(fila).Cells[index].Value.ToString()); //el valor de la celda es un objeto, lo paso a string primero y despues lo convierto a int
            index = grillaTurnos.Columns["Enfermedades"].Index;
            consulta.enfermedades = grillaTurnos.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaTurnos.Columns["Síntomas"].Index;
            consulta.sintomas = grillaTurnos.Rows.SharedRow(fila).Cells[index].Value.ToString();
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

        private void checkConsultaSinResultado_CheckedChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

    }
}
