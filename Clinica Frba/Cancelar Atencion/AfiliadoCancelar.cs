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

// toma el template "BaseCancelarAtencion" y lo adapta para la cancelacion de turnos por un afiliado
namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class AfiliadoCancelar : BaseCancelarAtencion
    {
        public AfiliadoCancelar(Form padre): base(padre)
        {
            InitializeComponent();
            cancelarAtencion.Location = buscar.Location;
            cancelarPeriodo.Visible = false;
            buscar.Visible = false;

            this.ActualizarGrilla();
        }

        override protected DataTable llenarGrilla() 
        {
            Persona p = UsuarioLogeado.Instance.Persona;

            return AppCancelarAtencion.traerTurnosAfiliado(p.nombre ,p.apellido, p.nroDoc, p.tipoDoc);
        }
    }
}
