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

//Funcionalidad que permite comprar bonos por parte de un afiliado, que luego podra ser 
//utilizados por su grupo farmiliar. 
//Se especifica cantidades para consulta y farmacia y luego muestra el monto total a pagar

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class CompraBono : Form
    {
        private Form padre;

        public CompraBono(Form padre)
        {
            InitializeComponent();
            this.padre = padre;

            var usuario = UsuarioLogeado.Instance;

            //primero me fijo si el que está logueado es un usuario. si es así, cargo sus datos directamente y oculto los controles de admin

            if (usuario.Rol.nombre.Equals("Afiliado"))
            {
                Afiliado paciente = (Afiliado) UsuarioLogeado.Instance.Persona;
                labNroAfiliado.Text = paciente.nroAfiliado.ToString();
                llenarCamposConDatosSocio(Convert.ToDecimal(paciente.nroAfiliado.ToString()));
                //como este form me muestra el botón quitar (porque también lo usa el admin), lo oculto
                botonQuitarAfiliado.Visible = false;
            }
        
        
        }

        private void botonRegreso_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void botonComprar_Click(object sender, EventArgs e)
            //botón de comprar
        {
            int cant_consulta;
            int cant_farmacia;
            decimal nro_afiliado;
            int monto_total;

            //tengo que validar que haya un afiliado cargado porque en el caso del admin puede no haber
            if (labNroAfiliado.Visible == false)
            {
                MessageBox.Show("Debe seleccionar un afiliado.", "Error");
                return;
            }
            
            nro_afiliado = Convert.ToDecimal(labNroAfiliado.Text);

            //me fijo que me estén poniendo cantidades enteras de bonos
            try
            {
                cant_consulta = Convert.ToUInt16(textCantBonosConsulta.Text);
                cant_farmacia = Convert.ToUInt16(textCantBonosFarmacia.Text);
            }
            catch
            {
                MessageBox.Show("Por favor ingrese cantidades válidas de bonos", "Error");
                return;
            }

            //me fijo que me estén comprando al menos un bono
            if(cant_consulta== 0 && cant_farmacia == 0)
            {
                MessageBox.Show("Debe comprar al menos un bono", "Información");
                return;
            }

            monto_total = ConectorSQL.ejecutarProcedureWithReturnValue("comprarBonos", nro_afiliado, cant_farmacia, cant_consulta, Globales.getFechaSistema());

            MessageBox.Show("Se realizó la compra solicitada. Importe total: $" + monto_total.ToString() + ".", "Éxito");
        }

        private void botonQuitarAfiliado_Click(object sender, EventArgs e)
            //oculto los detalles del afiliado y muestro lo necesario para cargar uno nuevo (sólo admin)
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
            
            try
            {
                Convert.ToUInt64(textBox1.Text); //esto me asegura que me pongan un nro de afiliado numérico bien
                num_afiliado = Convert.ToDecimal(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Debe ingresar un número de afiliado válido.", "Error");
                return;
            }

            labNroAfiliado.Text = textBox1.Text;
            llenarCamposConDatosSocio(Convert.ToDecimal(textBox1.Text));

        }


        private void llenarCamposConDatosSocio(decimal num_afiliado)
        //me traigo la info relevante del socio de la BD y la agrego al form  
        {
            DataTable datos_compra;

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

            
            labNroAfiliado.Visible = true;
            textBox1.Visible = false;

        }


    }
}
