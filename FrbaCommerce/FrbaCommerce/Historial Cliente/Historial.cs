using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial : Form
    {
        public string usuario;
        public Historial(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void compras_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new MuestraHistorial
                (
                delegate() 
                {
                    return AsistenteCliente.getHistorialCompras(usuario);
                }
                ));
        }

        private void ofertas_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new MuestraHistorial
                (
                delegate()
                {
                    return AsistenteCliente.getHistorialOfertas(usuario);
                }
                ));
        }
    }
}
