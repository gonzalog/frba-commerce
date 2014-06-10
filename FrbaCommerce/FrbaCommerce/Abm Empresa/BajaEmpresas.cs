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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class BajaEmpresas : Form
    {
        private Form padre;
        public BajaEmpresas(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando("", "", ""));
            cargarBotonBaja();
        }
        private void cargarBotonBaja()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = col.Name = "DAR DE BAJA";
            col.UseColumnTextForButtonValue = true;
            grillaEmpresas.Columns.Add(col);
        }

        private void elecCUIT_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericosOGuion(elecCUIT);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando(elecRS.Text, elecCUIT.Text, elecEMail.Text));
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            TextBox[] filtros = new TextBox[3] { elecRS, elecCUIT, elecEMail };
            foreach (TextBox filtro in filtros) filtro.Text = "";
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando("", "", ""));
        }

        private void grillaEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaEmpresas[0, e.RowIndex].Value == null)
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
                DataGridViewCellCollection celdas = grillaEmpresas.Rows[e.RowIndex].Cells;
                string empresaADarDeBaja = celdas["Usuario"].Value.ToString();
                if (e.ColumnIndex == celdas["DAR DE BAJA"].ColumnIndex)
                {
                    if (MessageBox.Show("¿Realmente desea dar de baja a " + empresaADarDeBaja + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            AsistenteUsuario.inhabilitarUsuario(empresaADarDeBaja);
                            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando(elecRS.Text, elecCUIT.Text, elecEMail.Text));
                        }
                        catch (BajaYaEfectuada)
                        {
                            MessageBox.Show(empresaADarDeBaja + " ya se encontraba dado de baja.");
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }
    }
}
