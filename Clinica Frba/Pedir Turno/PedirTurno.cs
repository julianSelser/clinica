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

namespace Clinica_Frba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        Form padre;
        Profesional profesional;
        Afiliado afiliado;

        internal PedirTurno(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
            if (UsuarioLogeado.Instance.Rol.nombre == "Afiliado") setearAfiliado(UsuarioLogeado.Instance.Persona as Afiliado);
            else
            {
                new ListadoAfiliados(this, "Pedir Turno").ShowDialog();
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
    }
}
