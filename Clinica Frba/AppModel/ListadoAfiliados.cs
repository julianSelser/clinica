using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Domain;
using Clinica_Frba.Abm_de_Afiliado;
using Clinica_Frba.Pedir_Turno;
using Clinica_Frba.Registro_de_LLegada;

//inicializa una nueva ventana con la lista de afiliados,
//se puede filtrar por criterios y al seleccionar una fila se comporta distinto
//segun el tipo de funcionalidad especificada que recibio por parametro

namespace Clinica_Frba.AppModel
{
    public partial class ListadoAfiliados : Form
    {
        public Form padre;
        public string funcion;
        List<PlanMedico> planesMedicos;

        public ListadoAfiliados(Form padre, string funcion)
        {
            InitializeComponent();
            this.padre = padre;
            this.funcion = funcion;
            cargarPlanesMedicos();
            cargarGrilla();
            ocultarColumnas();
            cargarBotonFuncionalidad();
            validarCampos();
        }

        private void cargarPlanesMedicos()
        {
            planesMedicos = AppAfiliado.traerPlanesMedicos();
        }


        private void ocultarColumnas() //oculto las columnas que no son de interes
        {
            grillaAfiliados.Columns["Nª Afiliado de Titular"].Visible = false;
            grillaAfiliados.Columns["Nª Afiliado de Conyuge"].Visible = false;
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
            AsistenteVistas.cargarGrilla(grillaAfiliados, AppAfiliado.getAfiliados(nombreBox.Text, apellidoBox.Text, "", 0,nroAfiliadoRaizBox.Text));
        }

        private int getCodigoPlan(string descripcion)
        {
            foreach (PlanMedico plan in planesMedicos)
            {
                if (plan.descripcion == descripcion) return plan.codigo;
            }
            throw new Exception("Descripcion no encuentra correspondiente codigo de plan medico.\nDetalle: " + descripcion);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos(); //Limpia los campos
        }

        private void inicializarCampos()
        {
            nombreBox.Text = "";
            apellidoBox.Text = "";
            nroAfiliadoRaizBox.Text = "";
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Afiliado";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaAfiliados.Columns.Add(col);
        }

        private bool estaDadoDeBaja(DataGridViewRow fila)
        {
            int index = grillaAfiliados.Columns["Fecha de Baja"].Index;
            return fila.Cells[index].Value != null 
                && fila.Cells[index].Value.ToString() != "";
        }

        private void grillaAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaAfiliados.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaAfiliados.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaAfiliados.Rows[e.RowIndex];
                if (!estaDadoDeBaja(fila))
                {
                    Afiliado afiliado = crearAfiliado(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    switch (funcion)
                    {
                        case "Baja":
                            AsistenteVistas.mostrarNuevaVentana(new BajaAfiliado(this, afiliado), this);
                            break;
                        case "Modificar":
                            AsistenteVistas.mostrarNuevaVentana(new PeticionAccion(afiliado, this), this);
                            break;
                        case "Pedir Turno":
                            volverAVistaPedirTurno(afiliado);
                            break;
                        case "Registrar Llegada":
                            volvarAVistaRegistroLlegada(afiliado);
                            break;
                        case "Registrar Resultado":
                            volverAVistaRegistrarResultado(afiliado);
                            break;
                        default:
                            break;
                    }
                }
                else MessageBox.Show("El afiliado seleccionado se encuentra dado de baja");
            }
            
        }

        private void volverAVistaRegistrarResultado(Afiliado afiliado)
        {
            (padre as ListadoConsultas).setearAfiliado(afiliado);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void volvarAVistaRegistroLlegada(Afiliado afiliado)
        {
            (padre as RegistroLlegada).setearAfiliado(afiliado);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void volverAVistaPedirTurno(Afiliado afiliado)
        {
            (padre as PedirTurno).setearAfiliado(afiliado);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private Afiliado crearAfiliado(int fila)
        {
            Afiliado afiliado = new Afiliado();
            int index = grillaAfiliados.Columns["Nª Afiliado"].Index;
            afiliado.nroAfiliado = Convert.ToInt32(grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString()); //el valor de la celda es un objeto, lo paso a string primero y despues lo convierto a int
            index = grillaAfiliados.Columns["Dirección"].Index;
            afiliado.direccion = grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaAfiliados.Columns["Mail"].Index;
            afiliado.mail = grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaAfiliados.Columns["Teléfono"].Index;
            afiliado.telefono = Convert.ToInt64(grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaAfiliados.Columns["Plan Medico"].Index;
            afiliado.codPlan = getCodigoPlan(grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaAfiliados.Columns["Estado Civil"].Index;
            afiliado.estadoCivil = grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaAfiliados.Columns["Cantidad de Familiares a Cargo"].Index;
            afiliado.cantFamiliaresACargo = Convert.ToInt32(grillaAfiliados.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return afiliado;
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", nombreBox.Text, false, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Apellido", apellidoBox.Text, false, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Nro Afiliado Raiz", nroAfiliadoRaizBox.Text, false, Controlador.TipoValidacion.Codigo));
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

        private void ListadoAfiliados_Activated(object sender, EventArgs e)
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

        private void nroAfiliadoRaizBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }
    }
}
