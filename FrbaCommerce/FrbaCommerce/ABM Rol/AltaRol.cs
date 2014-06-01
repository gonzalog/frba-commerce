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
    public partial class AltaRol : Form
    {
        private Form padre {set; get; }

        public AltaRol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
    }
}
