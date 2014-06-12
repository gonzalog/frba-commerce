using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class VerPublicacionesAEditar : Form
    {
        public string user;
        public VerPublicacionesAEditar(string user)
        {
            InitializeComponent();
            this.user = user;
            cargarPublics();
            agregarBotonEditar();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            descripBox.Text = "";
            cargarPublics();
        }
        private void cargarPublics()
        {
            AsistenteVistas.CargarGrilla(grillaPublics, AsistentePublicacion.getPublicsBuscando(descripBox.Text,user));
        }

        public void agregarBotonEditar()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "EDITAR";
            col.Name = "EDITAR";
            col.UseColumnTextForButtonValue = true;
            grillaPublics.Columns.Add(col);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            cargarPublics();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grillaPublics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaPublics[0, e.RowIndex].Value == null)
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
                int publicAModificar = Convert.ToInt32(grillaPublics.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                if (e.ColumnIndex == grillaPublics.Rows[e.RowIndex].Cells["EDITAR"].ColumnIndex)
                {
                    //AsistenteVistas.mostrarNuevaVentana((new CambiarFunciones(rolAModificar, this)), this);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }
        }
    }
}
