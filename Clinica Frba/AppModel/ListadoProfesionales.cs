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
using Clinica_Frba.Abm_de_Profesional;
using Clinica_Frba.Registro_de_LLegada;
using Clinica_Frba.Pedir_Turno;

//inicializa una nueva ventana con la lista de afiliados,
//se puede filtrar por criterios y al seleccionar una fila se comporta distinto
//segun el tipo de funcionalidad especificada que recibio por parametro

namespace Clinica_Frba.AppModel
{
    public partial class ListadoProfesionales : Form
    {
        public Form padre;
        public string funcion;
        public List<EspecialidadMedica> listaEspecialidades;

        public ListadoProfesionales(Form padre, string funcion)
        {
            InitializeComponent();
            this.padre = padre;
            this.funcion = funcion;
            cargarGrilla();
            cargarEspecialidades();
            cargarBotonFuncionalidad();
            validarCampos();
        }

        private void cargarEspecialidades()
        {
            listaEspecialidades = AppProfesional.getEspecialidades();
            foreach (EspecialidadMedica especialidad in listaEspecialidades)
            {
                comboEspecialidad.Items.Add(especialidad.descripcion);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            try
            {   //Se carga la grilla ejecutando el procedure con los valores de filtro como parametro
                cargarGrilla();
            }
            catch (Exception ex)
            {
                ErrorManager.fatalError(padre, this, ex);
            }
        }

        public void cargarGrilla()
        {
            int matricula = 0;
            int especialidad = 0;
            if (matriculaBox.Text != "") matricula = Convert.ToInt32(matriculaBox.Text);
            if(comboEspecialidad.SelectedIndex != -1)
            {
               especialidad = getCodigoEspecialidad(comboEspecialidad.SelectedItem.ToString());
            }
            AsistenteVistas.cargarGrilla(grillaProfesionales, AppProfesional.traerDataTableMedicos(nombreBox.Text, apellidoBox.Text, matricula, especialidad));
        }

        private int getCodigoEspecialidad(string descripcion)
        {
            foreach (EspecialidadMedica especialidad in listaEspecialidades)
            {
                if (especialidad.descripcion == descripcion) return especialidad.codigo;
            }
            throw new Exception("Codigo de especialidad no encontrado");
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos(); //Limpia los campos
        }

        private void inicializarCampos()
        {
            nombreBox.Text = "";
            apellidoBox.Text = "";
            matriculaBox.Text = "";
            comboEspecialidad.SelectedIndex = -1;
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Profesional";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaProfesionales.Columns.Add(col);
        }

        private bool estaDadoDeBaja(DataGridViewRow fila) //verifica si el profesional ya esta dado de baja
        {
            int index = grillaProfesionales.Columns["Habilitado"].Index;
            return !(bool)fila.Cells[index].Value;
        }

        private void grillaAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaProfesionales.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaProfesionales.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaProfesionales.Rows[e.RowIndex];
                if (!estaDadoDeBaja(fila))
                {
                    Profesional profesional = crearProfesional(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    switch (funcion)
                    {
                        case "Baja":
                            AsistenteVistas.mostrarNuevaVentana(new BajaProfesional(this, profesional), this);
                            break;
                        case "Modificar":
                            AsistenteVistas.mostrarNuevaVentana(new ModificarProfesional(this, profesional), this);
                            break;
                        case "Pedir Turno":
                            if(noTieneAgenda(fila)) //chequea que tenga fecha de atencion desde y hasta (quiere decir que tiene una agenda registrada)
                            {
                                MessageBox.Show("ERROR: El profesional no tiene registrada una agenda", "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else{
                                if (comboEspecialidad.SelectedIndex != -1)
                                {
                                    EspecialidadMedica especialidad = crearEspecialidad();
                                    volverAVistaPedirTurno(profesional, especialidad);
                                }
                                else
                                {
                                    MessageBox.Show("ERROR: Debe especificar una especialidad", "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case "Registrar Llegada":
                            volvarAVistaRegistroLlegada(profesional);
                            break;
                        case "Registrar Resultado":
                            volverAVistaRegistrarResultado(profesional);
                            break;
                        default:
                            break;
                    }

                }
                else MessageBox.Show("El profesional seleccionado se encuentra inhabilitado");
            }
            
        }

        private bool noTieneAgenda(DataGridViewRow fila)
        {
            int index = grillaProfesionales.Columns["Fecha Atencion Desde"].Index;
            int index2 = grillaProfesionales.Columns["Fecha Atencion Hasta"].Index;
            return fila.Cells[index].Value.ToString() == "" && fila.Cells[index2].Value.ToString() == "";
        }

        private EspecialidadMedica crearEspecialidad()
        {
            try
            {
                EspecialidadMedica especialidad = new EspecialidadMedica();
                especialidad.codigo = getCodigoEspecialidad(comboEspecialidad.Text);
                especialidad.descripcion = comboEspecialidad.Text;
                return especialidad;
            }
            catch(Exception ex)
            {
                ErrorManager.fatalError(padre, this, ex);
                return null;
            }
        }

        private void volverAVistaRegistrarResultado(Profesional profesional)
        {
            (padre as ListadoConsultas).setearProfesional(profesional);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void volvarAVistaRegistroLlegada(Profesional profesional)
        {
            (padre as RegistroLlegada).setearProfesional(profesional);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void volverAVistaPedirTurno(Profesional profesional, EspecialidadMedica especialidad)
        {
            (padre as PedirTurno).setearProfesional(profesional, especialidad);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private Profesional crearProfesional(int fila)
        {
            Profesional profesional = new Profesional();
            int index = grillaProfesionales.Columns["ID Medico"].Index;
            profesional.id = Convert.ToInt32(grillaProfesionales.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaProfesionales.Columns["Direccion"].Index;
            profesional.direccion = grillaProfesionales.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaProfesionales.Columns["Telefono"].Index;
            profesional.telefono = Convert.ToInt64(grillaProfesionales.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaProfesionales.Columns["Mail"].Index;
            profesional.mail = grillaProfesionales.Rows.SharedRow(fila).Cells[index].Value.ToString();
            return profesional;
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", nombreBox.Text, false, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Apellido", apellidoBox.Text, false, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Matricula", matriculaBox.Text, false, Controlador.TipoValidacion.Codigo));
            try
            {
                Controlador.validarCampos(campos);
                buscarButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                buscarButton.Enabled = false;
            }
        }

        private void ListadoProfesionales_Activated(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void apellidoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
            validarCampos();
        }

    }
}
