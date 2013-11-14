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

        }
    }
}
