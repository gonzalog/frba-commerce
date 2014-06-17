using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class DarPuntaje : Form
    {
        public Adquisicion adqui;
        public Calificar padre;
        public DarPuntaje(Adquisicion adqui,Calificar padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.adqui = adqui;
            this.Text = adqui.publicacion.descripcion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteCompra.altaCalificacion(Convert.ToInt32(numericUpDown1.Value),textBox1.Text,adqui.codigo,adqui.publicacion.tipo.nombreTipo());
            padre.recargar();
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }
    }
}
