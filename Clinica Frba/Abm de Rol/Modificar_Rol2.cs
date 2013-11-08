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
    public partial class Modificar_Rol2 : Form
    {
        Rol oldRol;

        private Form padre;
        public Modificar_Rol2(Form padre)
        {
            InitializeComponent();
            this.padre = padre;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        //IMP: el int lo voy a tener que guardar en una variable glogal cuando lo llame de la vista anteior 
        public void cargarFuncionalidades()
        {
            chkBoxFuncionalidades.Items.Clear(); //los vacia
            var items = chkBoxFuncionalidades.Items;
            //List<String> funcionalidades = AppRol.getFuncionalidadesRol(/*falta el int*/);
            //List<Funcionalidad> funcionalidadesHabilitadas = oldRol.getFuncionalidades();

            // (Funcionalidad func in funcionalidades)
            //{
            //    items.Add(func, func.estaEnLista(funcionalidadesHabilitadas));
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevoNombre = this.textBoxRol.Text;//pongo el nuevo nombre en una variable
            int codRol = oldRol.id;
            List<Funcionalidad> funcsAgregadas = this.getFuncionalidadesAgregadas();
            List<Funcionalidad> funcsAQuitar = this.getFuncionalidadesAQuitar();
            if (_seRealizaronModificaciones(nuevoNombre, funcsAgregadas, funcsAQuitar, habilitado))
            {
                DAORol.modificarRol(oldRol, codRol, nuevoNombre, habilitado, funcsAgregadas, funcsAQuitar);
                MessageBox.Show("El rol ha sido modificado exitosamente.");
                _padre.cargarGrid(DAORol.getDataTableRoles());
                this.Close();
            }
            else
            {
                MessageBox.Show("No ha modificado el Rol.");
            }
        }
    }
}
