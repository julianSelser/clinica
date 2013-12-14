using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.AppModel;
using Clinica_Frba.AppModel.Excepciones;
using Clinica_Frba.Domain;

//Funcionalidad que permite dar de alta a un médico con sus respectivas especialidades

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class AltaProfesional : Form
    {
        private Form padre;
        private char sexo;
        List<EspecialidadMedica> especialidades;

        public AltaProfesional(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            cargarEspecialidades();
            masculinoRadioButton.Checked = true;
            sexo = 'M';
            masculinoRadioButton.Checked = true;
            validarCampos();
        }

        private void cargarEspecialidades()
        {
            especialidades = AppProfesional.getEspecialidades();
            foreach (EspecialidadMedica especialidad in especialidades)
            {
                especialidadesCheckedListBox.Items.Add(especialidad.descripcion);
            }    
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void masculinoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (masculinoRadioButton.Checked)
                sexo = 'M';
            else
                sexo = 'F';
        }

        private List<EspecialidadMedica> generarListaEspecialidades()
        {
            int cont = 0, cantidadEspecialidades = especialidadesCheckedListBox.CheckedItems.Count;
            if(cantidadEspecialidades == 0) throw new SinEspecilidadesCheckedException();
            List<EspecialidadMedica> lista = new List<EspecialidadMedica>();

            while (cont < cantidadEspecialidades)
            {
                EspecialidadMedica especialidad = new EspecialidadMedica();
                especialidad.codigo = getCodigoEspecialidad(especialidadesCheckedListBox.CheckedItems[cont].ToString());
                lista.Add(especialidad); //agrego las especialidades seleccionadas a una lista para luego relacionarlas con el medico
                cont++;
            }
            return lista;
        }

        private int getCodigoEspecialidad(string descripcion)
        {
            foreach (EspecialidadMedica elemento in especialidades)
            {
                if (elemento.descripcion == descripcion) return elemento.codigo;
            }
            throw new Exception("Codigo de especialidad no encontrado");
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {

            try
            {
                Profesional profesional = crearProfesional();
                List<EspecialidadMedica> listaEspecialidades = generarListaEspecialidades();
                AppProfesional.darAltaProfesional(profesional, listaEspecialidades);
                MessageBox.Show("El alta del médico se ha realizado con éxito.\n\nDetalle:\nId: "+profesional.id+"\nMédico: " + profesional.nombre + " " + profesional.apellido + "\n" + profesional.tipoDoc + ".: " + profesional.nroDoc);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (UserDefinedException ex)
            {
                ErrorManager.messageErrorBox(ex, "Alta Profesional");
            }
        }

        private Profesional crearProfesional()
        {
            Profesional profesional = new Profesional();
            profesional.nombre = nombreBox.Text;
            profesional.apellido = apellidoBox.Text;
            profesional.tipoDoc = tipoDocBox.Text;
            profesional.nroDoc = Convert.ToInt32(nroDocBox.Text);
            profesional.direccion = direcBox.Text;
            profesional.mail = mailBox.Text;
            profesional.nroMatricula = Convert.ToInt32(matriculaBox.Text);
            profesional.telefono = Convert.ToInt64(telBox.Text);
            profesional.sexo = sexo;
            profesional.fechaNac = fechaNacBox.Value;
            return profesional;
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", nombreBox.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Apellido", apellidoBox.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Tipo Documento", tipoDocBox.Text, true, Controlador.TipoValidacion.Alfa));
            campos.Add(new Campo("Numero Documento", nroDocBox.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Dirección", direcBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Teléfono", telBox.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Mail", mailBox.Text, false, Controlador.TipoValidacion.Email));
            campos.Add(new Campo("Número Matricula", matriculaBox.Text, true, Controlador.TipoValidacion.Codigo));

            try
            {
                Controlador.validarCampos(campos);
                acceptButton.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                acceptButton.Enabled = false;
            }
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void apellidoBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tipoDocBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void nroDocBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void direcBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void telBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void mailBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void matriculaBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            sexo = 'M';

            for (int i = 0; i < especialidadesCheckedListBox.Items.Count; i++ )
            {
                especialidadesCheckedListBox.SetItemChecked(i, false);
            }

            nombreBox.Text = "";
            apellidoBox.Text = "";
            masculinoRadioButton.Checked = true;
            direcBox.Text = "";
            telBox.Text = "";
            mailBox.Text = "";
            nroDocBox.Text = "";
            tipoDocBox.SelectedIndex = -1;
            fechaNacBox.Value = Convert.ToDateTime(Globales.getFechaSistema().ToShortDateString());
            matriculaBox.Text = "";

        }

    }
}
