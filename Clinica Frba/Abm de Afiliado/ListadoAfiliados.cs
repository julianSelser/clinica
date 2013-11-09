using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

//inicializa una nueva ventana con la lista de afiliados,
//se puede filtrar por criterios y al seleccionar una fila se comporta distinto
//segun el tipo de funcionalidad especificada que recibio por parametro

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ListadoAfiliados : Form
    {
        public Form padre;
        public string funcion;

        public ListadoAfiliados(Form padre, string funcion)
        {
            InitializeComponent();
            this.padre = padre;
            this.funcion = funcion;
            grillaAfiliados.ReadOnly = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenteVistas.cargarGrilla(grillaAfiliados, AppAfiliado.getAfiliados(nombreBox.Text, apellidoBox.Text, nroAfiliadoRaizBox.Text));
            }
            catch (Exception ex)
            {
                ErrorManager.fatalError(padre, this, ex);
            }
        }

    }
}
