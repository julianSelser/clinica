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
using Clinica_Frba.AppModel.Excepciones;

//Funcionalidad para dar de alta un rol

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class Alta_Rol : Form
    {
        private Form padre;
        List<Funcionalidad> funcionalidades;

        public Alta_Rol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            cargarFuncionalidades();
            validarCampos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cargarFuncionalidades()
        {
            funcionalidades = AppRol.getFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                checkedListBox1.Items.Add(funcionalidad.descripcion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = crearRol();
                List<Funcionalidad> listaFuncionalidades = generarListaFuncionalidades();
                AppRol.darAltaRol(rol, listaFuncionalidades);
                MessageBox.Show("El alta del rol se ha realizado con éxito.\n\nDetalle:\nId: " + rol.id + "\nRol: " + rol.nombre);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (UserDefinedException ex)
            {
                ErrorManager.messageErrorBox(ex, "Alta Rol");
            }
        }

        private Rol crearRol()
        {
            Rol rol = new Rol();
            rol.nombre = textBox1.Text;
            return rol;
        }

        private List<Funcionalidad> generarListaFuncionalidades()
        {
            int cont = 0, cantidadFuncionalidades = checkedListBox1.CheckedItems.Count;
            if (cantidadFuncionalidades == 0) throw new SinFuncionalidadesCheckedException();
            List<Funcionalidad> lista = new List<Funcionalidad>();

            while (cont < cantidadFuncionalidades)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = getIdFuncionalidad(checkedListBox1.CheckedItems[cont].ToString());
                lista.Add(funcionalidad); //agrego las especialidades seleccionadas a una lista para luego relacionarlas con el medico
                cont++;
            }
            return lista;
        }


        private int getIdFuncionalidad(string descripcion)
        {
            foreach (Funcionalidad elemento in funcionalidades)
            {
                if (elemento.descripcion == descripcion) return elemento.id;
            }
            throw new Exception("Id de funcionalidad no encontrado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }


        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", textBox1.Text, true, Controlador.TipoValidacion.Alfa));

            try
            {
                Controlador.validarCampos(campos);
                button1.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                button1.Enabled = false;
            }
        }


    }
}
