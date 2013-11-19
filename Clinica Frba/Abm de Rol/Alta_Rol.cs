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
            Rol rol = crearRol();
            List<Funcionalidad> listaFuncionalidades = generarListaFuncionalidades();
            AppRol.darAltaRol(rol, listaFuncionalidades);
            MessageBox.Show("El alta del rol se ha realizado con éxito.\n\nDetalle:\nId: " + rol.id);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
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


    }
}
