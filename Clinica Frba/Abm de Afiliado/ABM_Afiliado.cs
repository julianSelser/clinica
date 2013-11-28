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

//Funcionalidad que permite a un administrador dar de alta, baja, o modificar un afiliado
//Cada funcionalidad se deriva en otra pantalla

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

        private void altaButton_Click(object sender, EventArgs e)
        {
            ModoAfiliado modoTitular = new ModoAfiliado(); //se crea una abstraccion que contiene el modo en que se inicia la ventana AltaAfiliado
            modoTitular.modo = "Titular";
            AsistenteVistas.mostrarNuevaVentana(new AltaAfiliado(modoTitular, this), this);
        }
        
        private void modificarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Modificar"), this); 
        }
        
        private void bajaButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Baja"), this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

    }
}
