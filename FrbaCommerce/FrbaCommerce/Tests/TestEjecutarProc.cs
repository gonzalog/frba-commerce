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
            Dictionary<string, object> args = new Dictionary<string, object>() 
            { 
                {"@nombre","rol_California"},
                {"@habilitado",0}
            };
            AdaptadorBD.EjecutarProcedimiento("alta_rol",args);
        }
    }
}
