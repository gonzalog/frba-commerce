using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class EditCompraInmediataPublicada : Form
    {
        public Publicacion publiAEditar;
        public EditCompraInmediataPublicada(Publicacion publi)
        {
            InitializeComponent();
            this.publiAEditar = publi;
            AsistenteBotones.hacerNoEditables(estado);
            estado.Items.AddRange(new string[2]{"Publicada","Pausa"});
            estado.Text = "Publicada";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            publiAEditar.setEstado(estado.Text);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            int aumento = Convert.ToInt32(aumentadorDeStock.Value);
            System.Diagnostics.Debug.WriteLine("Se ordena aumentar el stock en: "+aumento);
            publiAEditar.aumentarStockEn(aumento);
            publiAEditar.perdurar();
            Close();
        }
    }
}
