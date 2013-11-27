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


//Funcionalidad que permite dar de alta un turno por parte del afiliado con el profesional que desea atenderse

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        Form padre;
        Profesional profesional;
        Afiliado afiliado;

        internal PedirTurno(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            if (UsuarioLogeado.Instance.Rol.nombre == "Afiliado")
            {
                setearAfiliado(UsuarioLogeado.Instance.Persona as Afiliado);
                selectAfiliadoButton.Visible = false;
            }
            cargarBotonFuncionalidad();
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Fecha";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaFechas.Columns.Add(col);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }


        internal void setearAfiliado(Afiliado afiliado)
        {
            this.afiliado = afiliado;
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
            validarCampos();
        }

        internal void setearProfesional(Profesional profesional)
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
            validarCampos();
        }

        private void selectAfiliadoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Pedir Turno"), this);
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Pedir Turno"), this);
        }

        private void validarCampos()
        {
            if(nroAfiliadoBox.Text != "" && profesionalBox.Text != "")
            {
               cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaFechas, AppPedirTurno.traerFechasAgenda(profesional));
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.Instance.Rol.nombre != "Afiliado")
            {
                nroAfiliadoBox.Text = "";
                afiliado = null;
            }
            profesionalBox.Text = "";
            profesional = null;
            grillaFechas.DataSource = null;
        }

        private void grillaFechas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaFechas.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaFechas.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {

                DateTime fechaAgenda = crearFecha(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                AsistenteVistas.mostrarNuevaVentana(new SeleccionarTimeslot(this, profesional, fechaAgenda),this);
            }
        }

        private DateTime crearFecha(int fila)
        {
            throw new NotImplementedException();
        }

    }
}
