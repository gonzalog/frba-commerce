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
using FrbaCommerce.Conector;

namespace FrbaCommerce.Tests
{
    public partial class TestEjecutarProc : Form
    {
        public TestEjecutarProc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaptadorBD.ejecutarProcedure("alta_rol", "rol_California",0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int retorno = AdaptadorBD.ejecutarProcedureWithReturnValue("rol_habilitacion", 1);
            MessageBox.Show(retorno.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Run(new TestMostrarRoles());
        }
    }
}
