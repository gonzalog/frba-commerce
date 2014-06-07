using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Login
{
    public partial class ElegirRol : Form
    {
        private string usuario;
        private Form padre;
        private Dictionary<string,int> rolesElegibles;

        public ElegirRol(string usuario, Form padre)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.padre = padre;
            this.rolesElegibles = AsistenteRol.getRolesDe(usuario);
            elecRol.Items.AddRange(this.rolesElegibles.Keys);
            elecRol.ReadOnly = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.rolesElegibles.Keys.Contains(elecRol.Text))
            {
                AsistenteVistas.mostrarNuevaVentana(new PantallaPrincipal(this.usuario, this.rolesElegibles[elecRol.Text], this), this);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol para ingresar.");
            }
        }
    }
}
