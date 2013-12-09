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

//Funcionalidad que permite generar la receta para un paciente dada una determinada consulta que se realizó y
//especificando un bono de farmacia para que pueda utilizar.
//Solo se pueden recetar como máximo 5 medicamentos en la receta, con una cantidad entre 1 o 3 del mismo como tope.
//En caso de que lo que se requiera supere las restricciones, tendra que especificar otra receta con otro bono de farmacia.

namespace Clinica_Frba.Generar_Receta
{
    public partial class GenerarReceta : Form
    {
        private Form padre;
        ConsultaMedica consulta { get; set; }
        Afiliado afiliado { get; set; }
        BonoFarmacia bono { get; set; }
        public Medicamento medicamento_aux { get; set; }
        List<Medicamento> medicamentosDeLaReceta { get; set; }

        public GenerarReceta(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            generarMedicamentos();
            selecBonoButton.Enabled = false;
            aceptarButton.Enabled = false;
            comboCantidad1.Enabled = false;
            comboCantidad2.Enabled = false;
            comboCantidad3.Enabled = false;
            comboCantidad4.Enabled = false;
            comboCantidad5.Enabled = false;
        }

        private void generarMedicamentos() //Inicializo la lista de medicamentos, que a priori estan vacios
        {
 	        medicamentosDeLaReceta = new List<Medicamento>();
            for(int i = 0; i < 5; i++)
            {
                 medicamentosDeLaReceta.Add(new Medicamento());
            }
        }

        private void selectConsultaButton_Click(object sender, EventArgs e) //muestra un listado de consultas para buscar segun afiliado y profesional
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoConsultas(this, "Generar Receta"),this);
        }
        
        internal void setearConsulta(ConsultaMedica consulta) //metodo que sera utilizado por el listado de consultas para setear la consulta
        {
            this.consulta = consulta;
            consultaBox.Text = consulta.idConsulta.ToString();
        }

        internal void setearAfiliado(BonoFarmacia bono) //metodo que sera utilizado por el listado de consultas para setear el afiliado
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
            List<Medicamento> medicamentosEnNull = new List<Medicamento>(); ;
            foreach (Medicamento medicamento in medicamentosDeLaReceta)
            {
                if (medicamento.cantidad == 0) medicamentosEnNull.Add(medicamento);
            }
            foreach (Medicamento medicamentoEnNull in medicamentosEnNull)
            {
                medicamentosDeLaReceta.Remove(medicamentoEnNull);
            }
            AppReceta.registrarReceta(afiliado, consulta, bono, medicamentosDeLaReceta); //genero la receta y la persisto
            MessageBox.Show("La receta médica se ha generado con éxito.");
            DialogResult resultado = MessageBox.Show("¿Desea recetar más medicamentos para la consulta?", "Confirmar", MessageBoxButtons.OKCancel); //si se desea recetar mas medicamentos porque son mas de 5, se ejecuta otra vez la funcionalidad con los mismos datos
            if (resultado == DialogResult.OK)
            {
                GenerarReceta ventanaGenerarReceta = new GenerarReceta(padre);
                AsistenteVistas.mostrarNuevaVentana(ventanaGenerarReceta, this);
                ventanaGenerarReceta.setearAfiliado(afiliado);
                ventanaGenerarReceta.setearConsulta(consulta);
                this.Close();
            }
            else
            {
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            
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

        private void setearMedicamento(TextBox medicamentoBox, int index)
        {
            (new SeleccionarMedicamento(this)).ShowDialog();
            medicamentosDeLaReceta[index] = medicamento_aux;
            medicamentoBox.Text = medicamento_aux.descripcion;
            
        }

        private void validarCampos() //habilita el boton de aceptar para generar la receta si se valida que esten las precondiciones OK
        {
            if (noExistenMedicamentosIguales()) aceptarButton.Enabled = false;
            else
            {
                if (consultaBox.Text != "" && bonoBox.Text != "" && existeAlMenosUnMedicamentoConCantidad() && todosLosMedicamentosTienenCantidad())
                {
                    aceptarButton.Enabled = true;
                }
                else
                {
                    aceptarButton.Enabled = false;
                }
            }
        }

        private bool todosLosMedicamentosTienenCantidad() //valido si todos los medicamentos tienen su respectiva cantidad
        {
            List<ComboBox> combos = new List<ComboBox>();
            combos.Add(comboCantidad1);
            combos.Add(comboCantidad2);
            combos.Add(comboCantidad3);
            combos.Add(comboCantidad4);
            combos.Add(comboCantidad5);

            foreach(ComboBox combo in combos){
                if (combo.Enabled && combo.SelectedIndex == -1) return false;
            }

            return true;
        }

        private bool noExistenMedicamentosIguales() //valida que no haya mas de un mismo medicamento recetado
        {
            int i;
            foreach (Medicamento medicamento in medicamentosDeLaReceta)
            {
                i = 0;
                foreach (Medicamento otroMedicamento in medicamentosDeLaReceta)
                {
                    if (otroMedicamento.nroMedicamento != 0 && otroMedicamento.nroMedicamento == medicamento.nroMedicamento) i++;
                }
                if (i > 1) 
                {
                    errorBox.Text = "No se puede recetar más de una vez el mismo medicamento en la receta";
                    return true;
                };
            }
            errorBox.Text = "";
            return false;
        }

        private bool existeAlMenosUnMedicamentoConCantidad() //validacion que permite generar una receta solo si existe al menos un medicamento con cantidad especificada
        {
            return (comboCantidad1.SelectedIndex != -1) ||
                (comboCantidad2.SelectedIndex != -1) ||
                (comboCantidad3.SelectedIndex != -1) ||
                (comboCantidad4.SelectedIndex != -1) ||
                (comboCantidad5.SelectedIndex != -1);
        }

        private void comboCantidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCantidad1.SelectedIndex != -1)
            {
                setearCantidadMedicamento(Convert.ToInt32(comboCantidad1.Text), 0);
                validarCampos();
            }
        }

        private void comboCantidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCantidad2.SelectedIndex != -1)
            {
                setearCantidadMedicamento(Convert.ToInt32(comboCantidad2.Text), 1);
                validarCampos();
            }
        }

        private void comboCantidad3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCantidad3.SelectedIndex != -1)
            {
                setearCantidadMedicamento(Convert.ToInt32(comboCantidad3.Text), 2);
                validarCampos();
            }
        }

        private void comboCantidad4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCantidad4.SelectedIndex != -1)
            {
                setearCantidadMedicamento(Convert.ToInt32(comboCantidad4.Text), 3);
                validarCampos();
            }
        }

        private void comboCantidad5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCantidad5.SelectedIndex != -1)
            {
                setearCantidadMedicamento(Convert.ToInt32(comboCantidad5.Text), 4);
                validarCampos();
            }
        }

        private void medicamentoBox1_TextChanged(object sender, EventArgs e)
        {
            if (medicamentoBox1.Text == "")
            {
                comboCantidad1.Enabled = false;
                comboCantidad1.SelectedIndex = -1;
            }
            else comboCantidad1.Enabled = true;
            validarCampos();
        }

        private void medicamentoBox2_TextChanged(object sender, EventArgs e)
        {
            if (medicamentoBox2.Text == "")
            {
                comboCantidad2.Enabled = false;
                comboCantidad2.SelectedIndex = -1;
            }
            else comboCantidad2.Enabled = true;
            validarCampos();
        }

        private void medicamentoBox3_TextChanged(object sender, EventArgs e)
        {
            if (medicamentoBox3.Text == "")
            {
                comboCantidad3.Enabled = false;
                comboCantidad3.SelectedIndex = -1;
            }
            else comboCantidad3.Enabled = true;
            validarCampos();
        }

        private void medicamentoBox4_TextChanged(object sender, EventArgs e)
        {
            if (medicamentoBox4.Text == "")
            {
                comboCantidad4.Enabled = false;
                comboCantidad4.SelectedIndex = -1;
            }
            else comboCantidad4.Enabled = true;
            validarCampos();
        }

        private void medicamentoBox5_TextChanged(object sender, EventArgs e)
        {
            if (medicamentoBox5.Text == "")
            {
                comboCantidad5.Enabled = false;
                comboCantidad5.SelectedIndex = -1;
            }
            else comboCantidad5.Enabled = true;
            validarCampos();
        }

        private void selecMedicamento1_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox1, 0);
        }

        private void selecMedicamento2_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox2, 1);
        }

        private void selecMedicamento3_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox3, 2);
        }

        private void selecMedicamento4_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox4, 3);
        }

        private void selecMedicamento5_Click(object sender, EventArgs e)
        {
            setearMedicamento(medicamentoBox5, 4);
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
            selecBonoButton.Enabled = false;
            inicializarMedicamentos();
        }

        private void inicializarMedicamentos()
        {
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
            aceptarButton.Enabled = false;
            comboCantidad1.Enabled = false;
            comboCantidad2.Enabled = false;
            comboCantidad3.Enabled = false;
            comboCantidad4.Enabled = false;
            comboCantidad5.Enabled = false;
            errorBox.Text = "";
            medicamentosDeLaReceta.Clear();
            generarMedicamentos();
        }

        private void bonoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void setearCantidadMedicamento(int cantidad, int index)
        {
            medicamentosDeLaReceta[index].cantidad = cantidad;
        }

        private void limpiarMedicamentosButton_Click(object sender, EventArgs e)
        {
            inicializarMedicamentos();
        }


    }
}
