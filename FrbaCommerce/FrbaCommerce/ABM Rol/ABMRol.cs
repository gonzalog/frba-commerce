using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.ABM_Rol
{
    public partial class ABMRol : Form
    {
        private Form padre { get; set; }

        public ABMRol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AltaRol(this), this);
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ModificionRol(this, (PantallaPrincipal)padre), this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new Bajas(this, (PantallaPrincipal)padre), this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {

        }
    }
}
