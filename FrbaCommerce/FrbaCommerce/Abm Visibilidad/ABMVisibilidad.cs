using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class ABMVisibilidad : Form
    {
        public ABMVisibilidad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaVisibilidad(this), this);
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificarVisibilidad(this), this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new BajaVisibilidad(this), this);
        }
    }
}
