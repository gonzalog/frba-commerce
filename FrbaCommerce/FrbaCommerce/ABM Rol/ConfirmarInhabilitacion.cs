using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Rol
{
    public partial class ConfirmarInhabilitacion : Form
    {
        int rolAInhabilitar { get; set; }
        string nombreRolAInhabilitar { get; set; }

        public ConfirmarInhabilitacion(int rolAInhabilitar,string nombreDelRol)
        {
            InitializeComponent();
            this.rolAInhabilitar = rolAInhabilitar;
            this.nombreRolAInhabilitar = nombreDelRol;
        }

        private void ConfirmarInhabilitacion_Load(object sender, EventArgs e)
        {

        }
    }
}
