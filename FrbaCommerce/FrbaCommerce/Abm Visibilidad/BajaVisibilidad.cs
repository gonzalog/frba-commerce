using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class BajaVisibilidad : Form
    {
        public Form padre;
        public BajaVisibilidad(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            AsistenteVistas.CargarGrilla(grillaVisis, AsistenteVisibilidad.getTableBuscando(descripBox.Text));
            cargarBotonBaja();
        }

        private void cargarBotonBaja()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "DAR DE BAJA";
            col.Name = "BAJA";
            col.UseColumnTextForButtonValue = true;
            grillaVisis.Columns.Add(col);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaVisis, AsistenteVisibilidad.getTableBuscando(descripBox.Text));
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            descripBox.Text = "";
            AsistenteVistas.CargarGrilla(grillaVisis, AsistenteVisibilidad.getTableBuscando(""));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void grillaVisis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaVisis[0, e.RowIndex].Value == null)
                {
                    errorBox.Text = "Click inválido.";
                    return;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
                return;
            }
            try
            {
                DataGridViewCellCollection celdas = grillaVisis.Rows[e.RowIndex].Cells;
                string visiADarDeBaja = celdas["CÓDIGO"].Value.ToString();
                if (e.ColumnIndex == celdas["BAJA"].ColumnIndex)
                {
                    if (MessageBox.Show("¿Realmente desea dar de baja a " + visiADarDeBaja + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            AsistenteVisibilidad.inhabilitarVisibilidad(visiADarDeBaja);
                            AsistenteVistas.CargarGrilla(grillaVisis, AsistenteVisibilidad.getTableBuscando(descripBox.Text));
                        }
                        catch (BajaYaEfectuada)
                        {
                            MessageBox.Show(visiADarDeBaja+" ya se encontraba dada de baja.");
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }
        }
    }
}
