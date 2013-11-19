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

namespace Clinica_Frba.Registro_Resultado_Atencion
{
    public partial class RegistroResultadoAtencion : Form
    {
        private Form padre;

        public RegistroResultadoAtencion(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            if (UsuarioLogeado.Instance.Rol.nombre == "Profesional")
            {
                profesionalBox.Text = (UsuarioLogeado.Instance.Persona as Profesional).id.ToString();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

    }
}
