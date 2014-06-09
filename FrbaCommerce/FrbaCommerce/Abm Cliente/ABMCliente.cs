using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        public Form padre;
        public ABMCliente(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaCliente(this),this);
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificacionClientes(this), this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new BajaCliente(this), this);
        }
    }
}
