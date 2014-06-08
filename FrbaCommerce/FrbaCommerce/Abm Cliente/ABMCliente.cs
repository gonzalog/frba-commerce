using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
