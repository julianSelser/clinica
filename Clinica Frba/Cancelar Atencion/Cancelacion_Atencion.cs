using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class Cancelacion_Atencion : Form
    {
        private Form padre;

        public Cancelacion_Atencion(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
    }
}
