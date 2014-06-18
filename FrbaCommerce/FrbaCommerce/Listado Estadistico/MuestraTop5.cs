using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Abm_Visibilidad;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class MuestraTop5 : Form
    {
        public delegate DataTable traerTabla(string visi, int mes,bool usarMes);
        public traerTabla buscadorDeTabla;
        public MuestraTop5(traerTabla buscadorDeTabla,string tituloTop,int trimestre,int incrementoAlturaVentana)
        {
            InitializeComponent();
            this.titulo.Text = tituloTop;
            this.Height += incrementoAlturaVentana;

            this.buscadorDeTabla = buscadorDeTabla;
            buscarMes.Text = "1";
            cargarGrilla();
            AsistenteBotones.hacerNoEditables(buscarVisi,buscarMes);

            buscarVisi.Items.AddRange(AsistenteVisibilidad.getVisibilidades().Keys.ToArray());
            buscarVisi.Items.Add("");

            buscarMes.Items.Add((trimestre * 3) - 2);
            buscarMes.Items.Add((trimestre * 3) - 1);
            buscarMes.Items.Add(trimestre * 3);
        }

        public MuestraTop5(traerTabla buscadorDeTabla, string tituloTop)
        {
            InitializeComponent();
            this.titulo.Text = tituloTop;

            this.buscadorDeTabla = buscadorDeTabla;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                AsistenteVistas.CargarGrilla(grillaTopFive,
                    buscadorDeTabla(buscarVisi.Text, Convert.ToInt32(buscarMes.Text), opcionMes.Checked));
            }
            catch (Exception)
            {
                AsistenteVistas.CargarGrilla(grillaTopFive,
                    buscadorDeTabla(buscarVisi.Text, 0, opcionMes.Checked));
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            buscarVisi.Text = "";
            opcionMes.Checked = false;
            cargarGrilla();
        }

        private void buscarVisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void buscarMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void opcionMes_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }
    }
}
