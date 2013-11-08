using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class Baja_Rol : Form
    {
        private Form padre;
        public Baja_Rol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codRol = Convert.ToInt32(textBox1);//guardo lo que recibo del textbox
            AppRol.inhabilitarRol(codRol);//llamo a la funcion para darlo de baja
            AsistenteVistas.volverAPadreYCerrar(padre, this);//vuelvo a la ventana anterior
            //IMP:tendria que validar, y si no se ingreso ningun rol, mostrar un mensaje
        }
    }
}
