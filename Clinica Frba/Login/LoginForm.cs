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

// encargada de manejar el ingreso de usuario y contraseña y administrar un logeo
namespace Clinica_Frba.Login
{
    public partial class LoginForm : Form
    {
        PantallaPrincipal pantallaPrincipal;

        public LoginForm(PantallaPrincipal principal)
        {
            pantallaPrincipal = principal;
            InitializeComponent();
            InitializePassword();
        }

        private void InitializePassword()
        {
            passTextBox.Text = "";
            passTextBox.PasswordChar = '*';
            passTextBox.MaxLength = 16;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //cuando se intenta logear se devuelve un codigo que son los intentos o si no es de 1 a 3 es un codigo de error
            int n_intentos = AppLogin.intentarLogear(usrNameTextBox.Text, passTextBox.Text);
            
            //se acciona en base al intento de logeo (y el codigo o veces intentadas en n_intentos)
            if (0 == n_intentos) 
            {
                UsuarioLogeado.Instance.UserName = usrNameTextBox.Text;

                AsistenteVistas.mostrarNuevaVentana(new ElegirRol(pantallaPrincipal), this);
            }
            else
	        {
                if (n_intentos == -1)
                    MessageBox.Show("...error conectando con la base de datos...");
                else if(n_intentos < 3) 
                    MessageBox.Show("Contraseña erronea. Le quedan " + ( 3 - n_intentos ) + " intentos." );
                else if(n_intentos == 3)
                    MessageBox.Show("Contraseña erronea. Se procederá a deshabilitar su usuario por seguridad." );
                else if (n_intentos == 4)
                    MessageBox.Show("Su usuario se encuentra deshabilitado por razones de seguridad. " +
                                    "Consulte con su administrador para volver a habilitarlo.");
                else if(n_intentos == 5)
                    MessageBox.Show("No existe el usuario ingresado en el sistema");
	        }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(pantallaPrincipal, this);
        }

    }
}
