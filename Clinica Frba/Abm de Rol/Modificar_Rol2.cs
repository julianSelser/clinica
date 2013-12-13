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

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class Modificar_Rol2 : Form
    {
        private Form padre;
        Rol rol;
        PantallaPrincipal pantallaPrincipal; //necesita conocerla para manipular los botones
        List<Funcionalidad> funcionalidades;

        public Modificar_Rol2(Form padre, Rol rol, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent();
            this.pantallaPrincipal = pantallaPrincipal;
            this.padre = padre;
            this.rol = rol;
            validarHabilitado();
            cargarCampos();
            validarCampos();
            if (rol.nombre == "Administrativo" || rol.nombre == "Afiliado" || rol.nombre == "Profesional") textBox1.Enabled = false;
        }

        private void validarHabilitado() 
        {
            if (rol.habilitado == true) button3.Enabled = false;
        }

        private void cargarCampos()
        {
            idBox.Text = rol.id.ToString();
            textBox1.Text = rol.nombre;
            cargarFuncionalidades(); //ver si esta bien la logica de esto
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        //IMP: el int lo voy a tener que guardar en una variable glogal cuando lo llame de la vista anteior 
        public void cargarFuncionalidades()
        {

            int index;
            funcionalidades = AppRol.getFuncionalidades(); //cargo todas las especialidades
            List<Funcionalidad> funcionalidadesDelRol = AppRol.getFuncionalidadesRol(rol); //cargo las que ya tenia
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                chkBoxFuncionalidades.Items.Add(funcionalidad.descripcion);
                foreach (Funcionalidad funcionalidadDelRol in funcionalidadesDelRol)
                {
                    if (funcionalidadDelRol.id == funcionalidad.id)
                    {
                        index = chkBoxFuncionalidades.Items.IndexOf(funcionalidad.descripcion);
                        chkBoxFuncionalidades.SetItemChecked(index, true); //marco como seleccionada la especialidad que ya tenia
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarNombreRol();
                List<Funcionalidad> listaFuncionalidadesNuevas = generarListaFuncionalidades();
                AppRol.updateRol(rol, listaFuncionalidadesNuevas);

                if (rol.nombre == UsuarioLogeado.Instance.Rol.nombre)// este "if" es donde metio mano julian
                {
                    pantallaPrincipal.deshabilitarFuncionalidades(); //workaround: deshabilito todos los botones ya que se genera el listado solo de las funcionalidades a mostrar, no a ocultar
                    pantallaPrincipal.habilitarFuncionalidades(listaFuncionalidadesNuevas);
                }

                MessageBox.Show("La modificación del rol se ha realizado con éxito.\n\nId Rol: " + rol.id);
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
            catch (UserDefinedException ex)
            {
                ErrorManager.messageErrorBox(ex, "Modificación Rol");
            }
        }

        private void actualizarNombreRol()
        {
            rol.nombre = textBox1.Text;
        }

        private List<Funcionalidad> generarListaFuncionalidades()
        {
            int cont = 0, cantidadFuncionalidades = chkBoxFuncionalidades.CheckedItems.Count;
            if (cantidadFuncionalidades == 0) throw new SinFuncionalidadesCheckedException();
            List<Funcionalidad> lista = new List<Funcionalidad>();

            while (cont < cantidadFuncionalidades)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = getCodigoFuncionalidad(chkBoxFuncionalidades.CheckedItems[cont].ToString());
                lista.Add(funcionalidad);
                cont++;
            }
            return lista;
        }


        private int getCodigoFuncionalidad(string descripcion)
        {
            foreach (Funcionalidad elemento in funcionalidades)
            {
                if (elemento.descripcion == descripcion) return elemento.id;
            }
            throw new Exception("Codigo de funcionalidad no encontrado");
        }


        private void validarCampos()
        {
            List<CampoAbstracto> campos = new List<CampoAbstracto>();
            campos.Add(new Campo("Nombre", textBox1.Text, true, Controlador.TipoValidacion.Alfa));

            try
            {
                Controlador.validarCampos(campos);
                button1.Enabled = true;
                errorBox.Text = "";
            }
            catch (ExcepcionValidacion validacion)
            {
                errorBox.Text = validacion.mensaje;
                button1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rol.habilitado = true;
            AppRol.habilitarRol(rol);
            button3.Enabled = false;
            MessageBox.Show("El rol a sido habilitado.\n\nId Rol: " + rol.id);
        }

    }
}
