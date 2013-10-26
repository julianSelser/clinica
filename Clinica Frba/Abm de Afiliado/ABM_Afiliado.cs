using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ABM_Afiliado : Form
    {
        private Form padre;

        public ABM_Afiliado(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
    }
}
