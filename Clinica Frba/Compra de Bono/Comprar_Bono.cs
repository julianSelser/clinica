using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class Comprar_Bono : Form
    {
        private Form padre;

        public Comprar_Bono(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
    }
}
