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


    }
}
