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

//Funcionalidad que permite registrar la llegada de un afiliado a la clinica para validar su turno para atencion medica.
//En caso de llegar un segundo mas tarde de la hora estipulada del turno, la atencion se cancela.

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class RegistroLlegada : Form
    {
        private Form padre;
        Profesional profesional;
        Afiliado afiliado;

        internal RegistroLlegada(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        internal void setearAfiliado(Afiliado afiliado)
        {
            this.afiliado = afiliado;
            nroAfiliadoBox.Text = afiliado.nroAfiliado.ToString();
        }

        internal void setearProfesional(Profesional profesional)
        {
            this.profesional = profesional;
            profesionalBox.Text = profesional.id.ToString();
        }

        private void selectAfiliadoButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Registrar Llegada"), this);
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Registrar Llegada"), this);
        }
    }
}
