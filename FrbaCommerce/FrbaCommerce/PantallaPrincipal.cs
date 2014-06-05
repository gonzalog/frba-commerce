using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Login;
using FrbaCommerce.ABM_Rol;

namespace FrbaCommerce
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Logueo(this), this);

            //testing
            //AsistenteVistas.mostrarNuevaVentana(new ABMRol(this), this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n"+"Desarrollado por THE_DISCRETABOY");
        }
    }
}
