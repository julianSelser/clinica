using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Generar_Receta
{
    public partial class GenerarReceta : Form
    {
        private Form padre;

        public GenerarReceta(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

    }
}
