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

namespace Clinica_Frba.Generar_Receta
{
    public partial class GenerarReceta : Form
    {
        private Form padre;
        ConsultaMedica consulta;
        Afiliado afiliado;
        BonoFarmacia bono;

        public GenerarReceta(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            selecBonoButton.Enabled = false;
        }

        private void selectConsultaButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoConsultas(this, "Generar Receta"),this);
        }
        
        internal void setearConsulta(ConsultaMedica consulta)
        {
            this.consulta = consulta;
            consultaBox.Text = consulta.idConsulta.ToString();
        }

        internal void setearAfiliado(BonoFarmacia bono)
        {
            this.bono = bono;
            bonoBox.Text = bono.numero.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void consultaBox_TextChanged(object sender, EventArgs e)
        {
            selecBonoButton.Enabled = true;
        }

        private void selecBonoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ElegirBonoFarmacia(this, afiliado), this);
        }


        internal void setearAfiliado(Afiliado afiliado)
        {
            this.afiliado = afiliado;
        }

        internal void setearBonoFarmacia(BonoFarmacia bonoFarmacia)
        {
            this.bono = bonoFarmacia;
            bonoBox.Text = bonoFarmacia.numero.ToString();
        }
    }
}
