using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using System.Data.SqlClient;

namespace FrbaCommerce.Tests
{
    public partial class TestMostrarRoles : Form
    {
        public TestMostrarRoles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabla = AdaptadorBD.traerDataTable("traer_roles");
            AsistenteVistas.CargarGrilla(vistaDeRoles, tabla);
        }

    }
}
