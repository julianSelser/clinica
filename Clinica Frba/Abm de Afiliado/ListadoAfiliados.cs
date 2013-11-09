﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;
using Clinica_Frba.Domain;

//inicializa una nueva ventana con la lista de afiliados,
//se puede filtrar por criterios y al seleccionar una fila se comporta distinto
//segun el tipo de funcionalidad especificada que recibio por parametro

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ListadoAfiliados : Form, IListado
    {
        public Form padre;
        public string funcion;

        public ListadoAfiliados(Form padre, string funcion)
        {
            InitializeComponent();
            this.padre = padre;
            this.funcion = funcion;
            cargarGrilla();
            ocultarColumnas();
            cargarBotonFuncionalidad();
        }


        private void ocultarColumnas()
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
            AsistenteVistas.cargarGrilla(grillaAfiliados, AppAfiliado.getAfiliados(nombreBox.Text, apellidoBox.Text, nroAfiliadoRaizBox.Text));
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
            col.Text = funcion;
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
            if (e.ColumnIndex == grillaAfiliados.Columns["Seleccionar"].Index && e.RowIndex >= 0) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaAfiliados.Rows[e.RowIndex];
                if (!estaDadoDeBaja(fila))
                {
                    Afiliado afiliado = crearAfiliado(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                    if (funcion == "Baja") AsistenteVistas.mostrarNuevaVentana(new BajaAfiliado(this, afiliado), this);
                    if (funcion == "Modificar") AsistenteVistas.mostrarNuevaVentana(new ModificarAfiliado(this, afiliado), this);
                }
                else MessageBox.Show("El afiliado seleccionado esta de baja");
            }
            
        }

        private Afiliado crearAfiliado(int fila)
        {
            Afiliado afiliado = new Afiliado();
            afiliado.nroAfiliado = Convert.ToInt32(grillaAfiliados.Rows.SharedRow(fila).Cells[1].Value.ToString()); //el valor de la celda es un objeto, lo paso a string primero y despues lo convierto a int
           /* afiliado.nombre = nombre.Text;
            afiliado.apellido = apellido.Text;
            afiliado.sexo = sexo;
            afiliado.tipoDoc = tipoDoc.Text;
            afiliado.nroDoc = Convert.ToInt32(nroDoc.Text);
            afiliado.direccion = direccion.Text;
            afiliado.mail = mail.Text;
            afiliado.telefono = Convert.ToInt32(telefono.Text);
            afiliado.fechaNac = Convert.ToDateTime(fechaNacimiento.Value);
            afiliado.codPlan = Convert.ToInt32(planMedico.Text);
            afiliado.estadoCivil = estadoCivil.Text;
            afiliado.cantFamiliaresACargo = Convert.ToInt32(cantFamiliares.Text);*/
            return afiliado;
        }
    }
}
