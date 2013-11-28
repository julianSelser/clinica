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

//Funcionalidad que permite modificar a un profesional en los campos que son factibles de poder ser modificados

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ModificarProfesional : Form
    {
        private Form padre;
        Profesional profesional;
        List<EspecialidadMedica> especialidades;
        

        internal ModificarProfesional(Form padre, Profesional profesional)
        {
            InitializeComponent();
            this.padre = padre;
            this.profesional = profesional;
            cargarCampos();
            validarCampos();

        }

        private void cargarCampos()
        {
            idBox.Text = profesional.id.ToString();
            direcBox.Text = profesional.direccion;
            telBox.Text = profesional.telefono.ToString();
            mailBox.Text = profesional.mail;
            cargarEspecialidades();
        }

        private void cargarEspecialidades()
        {
            int index;
            especialidades = AppProfesional.getEspecialidades(); //cargo todas las especialidades
            List<EspecialidadMedica> especialidadesDelMedico = AppProfesional.getEspecialidadesMedico(profesional); //cargo las que ya tenia
            foreach (EspecialidadMedica especialidad in especialidades)
            {
                especialidadesCheckedListBox.Items.Add(especialidad.descripcion);
                foreach (EspecialidadMedica especialidadDelMedico in especialidadesDelMedico)
                {
                    if (especialidadDelMedico.codigo == especialidad.codigo)
                    {
                        index = especialidadesCheckedListBox.Items.IndexOf(especialidad.descripcion);
                        especialidadesCheckedListBox.SetItemChecked(index, true); //marco como seleccionada la especialidad que ya tenia
                    }
                }
            }
        }

        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Dirección", direcBox.Text, true, Controlador.TipoValidacion.Alfanumerico));
            campos.Add(new Campo("Teléfono", telBox.Text, true, Controlador.TipoValidacion.Codigo));
            campos.Add(new Campo("Mail", mailBox.Text, false, Controlador.TipoValidacion.Email));
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
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

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarAtributosProfesional();
                List<EspecialidadMedica> listaEspecialidadesNuevas = generarListaEspecialidades();
                AppProfesional.updateProfesional(profesional, listaEspecialidadesNuevas);
                MessageBox.Show("La modificación del médico se ha realizado con éxito.\n\nId Médico: " + profesional.id);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (UserDefinedException ex)
            {
                ErrorManager.messageErrorBox(ex, "Modificación Profesional");
            }
        }

        private void actualizarAtributosProfesional()
        {
            profesional.direccion = direcBox.Text;
            profesional.mail = mailBox.Text;
            profesional.telefono = Convert.ToInt32(telBox.Text);
        }

        private List<EspecialidadMedica> generarListaEspecialidades() //creo la nueva lista de especialidades del medico, iterando sobre cada item del CheckedListBox si fue selecionado
        {
            int cont = 0, cantidadEspecialidades = especialidadesCheckedListBox.CheckedItems.Count;
            if (cantidadEspecialidades == 0) throw new SinEspecilidadesCheckedException();
            List<EspecialidadMedica> lista = new List<EspecialidadMedica>();

            while (cont < cantidadEspecialidades)
            {
                EspecialidadMedica especialidad = new EspecialidadMedica();
                especialidad.codigo = getCodigoEspecialidad(especialidadesCheckedListBox.CheckedItems[cont].ToString());
                lista.Add(especialidad);
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

    }
}
