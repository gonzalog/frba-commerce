using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ABMEmpresa : Form
    {
        public ABMEmpresa()
        {
            InitializeComponent();
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
            AsistenteVistas.mostrarNuevaVentana(new AltaEmpresa(this), this);
        }
    }
}
