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
            aceptarButton.Enabled = false;
            comboCantidad1.Enabled = false;
            comboCantidad2.Enabled = false;
            comboCantidad3.Enabled = false;
            comboCantidad4.Enabled = false;
            comboCantidad5.Enabled = false;
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

        private void selecMedicamento1_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox1); 
        }

        private void setearMedicamento(TextBox medicamentoBox)
        {
            Medicamento medicamento = new Medicamento();
            AsistenteVistas.mostrarNuevaVentana(new SeleccionarMedicamento(this, medicamento), this);
            medicamentoBox.Text = medicamento.descripcion;
        }

        private void medicamentoBox2_TextChanged(object sender, EventArgs e)
        {
            comboCantidad2.Enabled = true;
        }

        private void validarCampos()
        {
            existeAlMenosUnMedicamentoConCantidad();
        }

        private void existeAlMenosUnMedicamentoConCantidad()
        {
            if (
                (medicamentoBox1.Text != "" && comboCantidad1.SelectedIndex != -1) ||
                (medicamentoBox2.Text != "" && comboCantidad2.SelectedIndex != -1) ||
                (medicamentoBox3.Text != "" && comboCantidad3.SelectedIndex != -1) ||
                (medicamentoBox4.Text != "" && comboCantidad4.SelectedIndex != -1) ||
                (medicamentoBox5.Text != "" && comboCantidad5.SelectedIndex != -1)
              )
            {
                aceptarButton.Enabled = true;
            }
            else
            {
                aceptarButton.Enabled = false;
            }
        }

        private void comboCantidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void comboCantidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void comboCantidad3_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void comboCantidad4_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void comboCantidad5_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void medicamentoBox1_TextChanged(object sender, EventArgs e)
        {
            comboCantidad1.Enabled = true;
        }

        private void medicamentoBox3_TextChanged(object sender, EventArgs e)
        {
            comboCantidad3.Enabled = true;
        }

        private void medicamentoBox4_TextChanged(object sender, EventArgs e)
        {
            comboCantidad4.Enabled = true;
        }

        private void medicamentoBox5_TextChanged(object sender, EventArgs e)
        {
            comboCantidad5.Enabled = true;
        }

        private void selecMedicamento2_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox2);
        }

        private void selecMedicamento3_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox3);
        }

        private void selecMedicamento4_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox4);
        }

        private void selecMedicamento5_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox5);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos();
            bono = null;
            consulta = null;
            afiliado = null;
            validarCampos();
        }

        private void inicializarCampos()
        {
            consultaBox.Text = "";
            bonoBox.Text = "";
            medicamentoBox1.Text = "";
            medicamentoBox2.Text = "";
            medicamentoBox3.Text = "";
            medicamentoBox4.Text = "";
            medicamentoBox5.Text = "";
            comboCantidad1.SelectedIndex = -1;
            comboCantidad2.SelectedIndex = -1;
            comboCantidad3.SelectedIndex = -1;
            comboCantidad4.SelectedIndex = -1;
            comboCantidad5.SelectedIndex = -1;
        }
    }
}
