using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class EditBorrador : Form
    {
        public Publicacion publiAEditar;
        public EditBorrador(Publicacion publi)
        {
            InitializeComponent();
            this.publiAEditar = publi;
            tipo.Text = publi.tipo.nombreTipo();
            Descripcion.Text = publi.descripcion;
            Stock.Text = Convert.ToString(publi.tipo.stock);
            Precio.Text = Convert.ToString(publi.tipo.precioInicial);
            Visibilidad.Text = publi.visibilidad.descripcion;
            Estado.Text = "Borrador";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Stock_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(Stock);
        }

        private void Precio_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloReales(Precio);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {

        }

        
    }
}
