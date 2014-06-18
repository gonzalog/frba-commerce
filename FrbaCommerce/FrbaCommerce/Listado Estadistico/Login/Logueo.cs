using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Login
{
    public partial class Logueo : Form
    {
        public Form padre;
        public Logueo(Form padre)
        {
            InitializeComponent();
            this.padre = padre;

            MinimizeBox = false;
            MaximizeBox = false;

            passTextBox.PasswordChar = '*';
            errorBox.Text = "Ingrese nombre de usuario y contraseña.";
        }

        private void passLabel_Click(object sender, EventArgs e)
        {

        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto+"\n"+"Desarrollado por THE_DISCRETABOY");
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            usrNameTextBox.Text = "";
            passTextBox.Text = "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            string userName = usrNameTextBox.Text;
            if (!AsistenteLogin.getHabilitadoUsuario(userName))
            {
                errorBox.Text = "'"+userName+"' no es un usuario habilitado. Por favor, compruebe que esté bien escrito y contactese con el administrador.";
                return;
            }
            int intentos = AsistenteLogin.intentarLoguear(userName,passTextBox.Text);

            if (intentos == 0)
            {
                errorBox.Text = "Logueo exitoso.";
                if (!AsistenteLogin.passwordPermanente(userName))
                {
                    MessageBox.Show("¡IMPORTANTE!\nLa contraseña que usted utilizó tiene una vida útil de solo un ingreso. Para poder volver a ingresar deberá ir al menú 'Cuenta'->'Cambiar contraseña' y reemplazarla por un nuevo valor a su antojo.");
                    AsistenteUsuario.inhabilitarUsuario(userName);
                }
                Dictionary<string, int> rolesDelUsuario = AsistenteRol.getRolesDe(userName);
                if (rolesDelUsuario.Count > 1)
                {
                    AsistenteVistas.mostrarNuevaVentana(new ElegirRol(userName, this), this);
                }
                else if (rolesDelUsuario.Count == 1)
                {
                    AsistenteVistas.mostrarNuevaVentana(new PantallaPrincipal(userName, rolesDelUsuario.Values.ElementAt(0), this), this);
                }
                else
                {
                    errorBox.Text = "Usted no dispone de un rol habilitado que le permita ingresar.";
                }
                return;
                
            }
            else if (intentos == 3)
            {
                AsistenteLogin.inhabilitarUsuario(userName);
                errorBox.Text = "Combinacion usuario/contraseña incorrecta. El usuario " + userName + " fue inhabilitado. Por favor, contacte al administrador.";
            }
            else
            {
                errorBox.Text = "Combinacion usuario/contraseña incorrecta. Intente nuevamiente.";
            }

            
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new OpcionTipoRegistro(this),this);
        }

    }
}
