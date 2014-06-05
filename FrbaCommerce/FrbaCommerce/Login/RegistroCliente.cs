using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Login
{
    public partial class RegistroCliente : Form
    {
        public Form padre;
        public RegistroCliente(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar? Se perderan todos los datos cargados.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AsistenteVistas.volverAPadreYCerrar(padre,this);
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (contenidoBotonesValido()) { 
            
            }
        }

        private bool contenidoBotonesValido() { 
            if(AsistenteUsuario.nombreValido());
        }
    }
}
