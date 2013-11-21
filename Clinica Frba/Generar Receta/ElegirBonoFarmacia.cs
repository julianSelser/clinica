using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Domain;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Generar_Receta
{
    public partial class ElegirBonoFarmacia : Form
    {
        Form padre;
        BonoFarmacia bono;
        Afiliado afiliado;

        internal ElegirBonoFarmacia(Form padre, Afiliado afiliado)
        {
            InitializeComponent();
            this.padre = padre;
            this.afiliado = afiliado;
            afiliadoBox.Text = afiliado.nroAfiliado.ToString();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            AsistenteVistas.cargarGrilla(grillaBonosFarmacia, AppReceta.traerBonosFarmacia(afiliado));
            cargarBotonFuncionalidad();
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Elegir Bono";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaBonosFarmacia.Columns.Add(col);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void grillaBonosFarmacia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grillaBonosFarmacia.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaBonosFarmacia.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                BonoFarmacia bonoFarmacia = armarBonoFarmacia(e.RowIndex);
                (padre as GenerarReceta).setearBonoFarmacia(bonoFarmacia);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
        }

        private BonoFarmacia armarBonoFarmacia(int fila)
        {
            bono = new BonoFarmacia();
            int index = grillaBonosFarmacia.Columns["Nro. de Bono"].Index;
            bono.numero = Convert.ToInt32(grillaBonosFarmacia.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return bono;
        }
    }
}
