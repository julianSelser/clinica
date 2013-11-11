using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class CompraBono : Form
    {
        private Form padre;

        public CompraBono(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void botonRegreso_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            int cant_consulta;
            int cant_farmacia;
            decimal nro_afiliado;
            int monto_total;

            if (labNroAfiliado.Visible == false)
            {
                MessageBox.Show("Debe seleccionar un afiliado.", "Error");
                return;
            }
            
            nro_afiliado = Convert.ToDecimal(labNroAfiliado.Text);

            try
            {
                cant_consulta = Convert.ToInt16(textCantBonosConsulta.Text);
                cant_farmacia = Convert.ToInt16(textCantBonosFarmacia.Text);
            }
            catch
            {
                MessageBox.Show("Por favor ingrese cantidades válidas de bonos", "Error");
                return;
            }

            monto_total = ConectorSQL.ejecutarProcedureWithReturnValue("comprarBonos", nro_afiliado, cant_farmacia, cant_consulta);

            MessageBox.Show("Se realizó la compra solicitada. Importe total: $" + monto_total.ToString() + ".", "Éxito");
        }

        private void botonQuitarAfiliado_Click(object sender, EventArgs e)
        {
            labNroPlan.Visible = false;
            labPrecioConsulta.Visible = false;
            labPrecioFarmacia.Visible = false;

            botonBuscarAfiliado.Visible = true;
            botonQuitarAfiliado.Visible = false;

            labNroAfiliado.Visible = false;
            textBox1.Visible = true;
        }

        private void botonBuscarAfiliado_Click(object sender, EventArgs e)
        {
            decimal num_afiliado;
            DataTable datos_compra;

            if (textBox1.Text.Length > 18)
            {
                MessageBox.Show("Debe ingresar un número de afiliado válido.", "Error");
                return;
            }

            try
            {
                num_afiliado = Convert.ToDecimal(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Debe ingresar un número de afiliado válido.", "Error");
                return;
            }


            datos_compra = ConectorSQL.traerDataTable("getDatosParaCompra", num_afiliado);

            if (datos_compra.Rows.Count.Equals(0))
            {
                MessageBox.Show("No se encontró al socio.", "Error");
                return;
            }

            labNroPlan.Text = datos_compra.Rows[0]["Descripcion"].ToString();
            labPrecioConsulta.Text = datos_compra.Rows[0]["Precio_Bono_Consulta"].ToString();
            labPrecioFarmacia.Text = datos_compra.Rows[0]["Precio_Bono_Farmacia"].ToString();

            labNroPlan.Visible = true;
            labPrecioConsulta.Visible = true;
            labPrecioFarmacia.Visible = true;

            botonBuscarAfiliado.Visible = false;
            botonQuitarAfiliado.Visible = true;

            labNroAfiliado.Text = textBox1.Text;
            labNroAfiliado.Visible = true;
            textBox1.Visible = false;

            
            

        }


    }
}
