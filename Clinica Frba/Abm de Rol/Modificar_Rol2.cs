using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;
using Clinica_Frba.AppModel.Excepciones;
using Clinica_Frba.Domain;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class Modificar_Rol2 : Form
    {
        private Form padre;
        Rol rol;
        List<Funcionalidad> funcionalidades;

        public Modificar_Rol2(Form padre, Rol rol)
        {
            InitializeComponent();
            this.padre = padre;
            this.rol = rol;
            cargarCampos();
            //validarCampos(); //por ahora no valido
        }


        private void cargarCampos()
        {
            idBox.Text = rol.id.ToString();
            cargarFuncionalidades(); //ver si esta bien la logica de esto
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        //IMP: el int lo voy a tener que guardar en una variable glogal cuando lo llame de la vista anteior 
        public void cargarFuncionalidades()
        {

            int index;
            funcionalidades = AppRol.getFuncionalidades(); //cargo todas las especialidades
            List<Funcionalidad> funcionalidadesDelRol = AppRol.getFuncionalidadesRol(rol); //cargo las que ya tenia
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                chkBoxFuncionalidades.Items.Add(funcionalidad.descripcion);
                foreach (Funcionalidad funcionalidadDelRol in funcionalidadesDelRol)
                {
                    if (funcionalidadDelRol.id == funcionalidad.id)
                    {
                        index = chkBoxFuncionalidades.Items.IndexOf(funcionalidad.descripcion);
                        chkBoxFuncionalidades.SetItemChecked(index, true); //marco como seleccionada la especialidad que ya tenia
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarNombreRol();
                List<Funcionalidad> listaFuncionalidadesNuevas = generarListaFuncionalidades();
                AppRol.updateRol(rol, listaFuncionalidadesNuevas);
                MessageBox.Show("La modificación del rol se ha realizado con éxito.\n\nId Rol: " + rol.id);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (UserDefinedException ex)
            {
                ErrorManager.messageErrorBox(ex, "Modificación Rol");
            }
        }

        private void actualizarNombreRol()
        {
            rol.nombre = textBox1.Text;
        }

        private List<Funcionalidad> generarListaFuncionalidades()
        {
            int cont = 0, cantidadFuncionalidades = chkBoxFuncionalidades.CheckedItems.Count;
            if (cantidadFuncionalidades == 0) throw new SinFuncionalidadesCheckedException();
            List<Funcionalidad> lista = new List<Funcionalidad>();

            while (cont < cantidadFuncionalidades)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = getCodigoFuncionalidad(chkBoxFuncionalidades.CheckedItems[cont].ToString());
                lista.Add(funcionalidad);
                cont++;
            }
            return lista;
        }


        private int getCodigoFuncionalidad(string descripcion)
        {
            foreach (Funcionalidad elemento in funcionalidades)
            {
                if (elemento.descripcion == descripcion) return elemento.id;
            }
            throw new Exception("Codigo de funcionalidad no encontrado");
        }

    }
}
