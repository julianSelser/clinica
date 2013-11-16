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


//Funcionalidad que permite dar de alta un turno por parte del afiliado con el profesional que desea atenderse

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        Form padre;
        Profesional profesional;
        Afiliado afiliado;

        internal PedirTurno(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            if (UsuarioLogeado.Instance.Rol.nombre == "Afiliado")
            {
                setearAfiliado(UsuarioLogeado.Instance.Persona as Afiliado);
                selectAfiliadoButton.Visible = false;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
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
            AsistenteVistas.mostrarNuevaVentana(new ListadoAfiliados(this, "Pedir Turno"), this);
        }

        private void selectProfesionalButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ListadoProfesionales(this, "Pedir Turno"), this);
        }
    }
}
