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

        private void grillaBonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grillaBonosFarmacia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
