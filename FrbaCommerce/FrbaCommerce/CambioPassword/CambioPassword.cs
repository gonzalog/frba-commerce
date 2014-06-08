using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.CambioPassword
{
    public partial class CambioPassword : Form
    {
        public string user;
        public CambioPassword(string user)
        {
            InitializeComponent();
            this.user = user;
            this.Text = this.Text + " de " + this.user + ".";
            passActual.PasswordChar = passFutura.PasswordChar = confirPassFutura.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (AsistenteUsuario.esPasswordCorrecta(this.user, passActual.Text))
            {
                if (passFutura.Text == confirPassFutura.Text)
                {
                    AsistenteUsuario.cambiarPassword(this.user, passFutura.Text);
                    status.Text = "Cambio de contraseña efectuado correctamente.";
                    MessageBox.Show("Cambio de contraseña efectuado correctamente.");
                    AsistenteUsuario.habilitarUsuario(this.user);
                    this.Close();
                    return;
                }
                else
                {
                    status.Text = "Las nueva conraseña no coincide con su confirmación.";
                    MessageBox.Show(status.Text+" Por favor, reescribalas e intente nuevamente.");
                    return;
                }
            }
            else
            {
                status.Text = "Contraseña actual incorrecta.";
                MessageBox.Show(status.Text + " Por favor, reescribala e intente nuevamente.");
                return;
            }
        }
    }
}
