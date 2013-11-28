using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

//ABM que tiene por objetivo dar de alta, baja o modificar un rol de usuario, con sus respectivas funcionalidades

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class ABM_Rol : Form
    {
        private Form padre;

        public ABM_Rol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Alta_Rol(this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoRoles(this, "Modificar", (PantallaPrincipal)padre), this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoRoles(this, "Baja", (PantallaPrincipal)padre), this);
            //es una vista intermedia que muestra un listado de roles
        }
    }
}
