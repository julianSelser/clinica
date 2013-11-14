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
    public partial class Baja_Rol : Form
    {
        private Form padre;
        internal Rol rol;

        public Baja_Rol(Form padre, Rol rol)
        {
            InitializeComponent();
            this.padre = padre;
            this.rol = rol;
            this.idBox.Text = rol.id.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AppRol.darBajaRol(rol);
            MessageBox.Show("La baja se ha realizado correctamente.");
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }
    }
}
