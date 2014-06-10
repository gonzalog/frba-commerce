using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class ModificarVisibilidad : Form
    {
        public Form padre;
        public ModificarVisibilidad(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            AsistenteVistas.CargarGrilla(grillaVisis, AsistenteVisibilidad.getTableBuscando(descripBox.Text));
            cargarBotonModificarDatos();
        }
        private void cargarBotonModificarDatos()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "EDITAR";
            col.Name = "EDICIÓN";
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
                int visibilidadAModificar = Convert.ToInt32(celdas["CÓDIGO"].Value.ToString());
                if (e.ColumnIndex == celdas["EDICIÓN"].ColumnIndex)
                {
                    AsistenteVistas.mostrarNuevaVentana((new EditarVisibilidad(visibilidadAModificar, this)), this);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }
        }
    }
}
