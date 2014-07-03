using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        public List<Adquisicion> pendientesMostrados;
        public string username;
        public Calificar(string username)
        {
            InitializeComponent();
            this.username = username;
            this.pendientesMostrados = AsistenteCliente.packComprasACalificar(username, 0);
            string[] codigos = pendientesMostrados.Select(com => "Producto comprado: " + com.publicacion.descripcion).ToArray();
            listado.Items.AddRange(codigos);
            label1.Text = "Pendientes: \n(Presione para calificar)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AsistenteVistas.mostrarNuevaVentana(new DarPuntaje(pendientesMostrados[listado.SelectedIndex], this), this);
            }
            catch (ArgumentOutOfRangeException)
            { 
                //Pasa cuando se clickea un renglón vacío del listado.
            }
        }

        public void recargar()
        {
            this.pendientesMostrados = AsistenteCliente.packComprasACalificar(username, 0);
            string[] codigos = pendientesMostrados.Select(com => com.publicacion.descripcion).ToArray();
            listado.Items.Clear();
            listado.Items.AddRange(codigos);
        }



    }
}
