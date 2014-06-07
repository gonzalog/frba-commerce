using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Login;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class OpcionTipoRegistro : Form
    {
        public Form padre;
        public OpcionTipoRegistro(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new RegistroCliente(this),this);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void nuevaEmpresa_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new RegistroEmpresa(this), this);
        }

    }
}
