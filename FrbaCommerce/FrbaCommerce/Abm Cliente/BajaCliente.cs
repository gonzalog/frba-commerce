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
    public partial class BajaCliente : Form
    {
        public Form padre;
        public BajaCliente(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
    }
}
