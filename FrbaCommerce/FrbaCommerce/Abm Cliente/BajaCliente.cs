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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class BajaCliente : Form
    {
        public Form padre;

        public BajaCliente(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            boxTipoDoc.Items.Add("DNI");
            boxTipoDoc.Items.Add("LE");
            boxTipoDoc.Items.Add("LC");
            boxTipoDoc.Items.Add("");
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
            cargarBotonDarDeBaja();
            boxTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargarBotonDarDeBaja()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "DAR DE BAJA";
            col.Name = "BAJA";
            col.UseColumnTextForButtonValue = true;
            grillaClientes.Columns.Add(col);
        }

        private void limpiarButton_Click_1(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            elecApe.Text = "";
            boxTipoDoc.Text = "";
            elecNroDoc.Text = "";
            elecEMail.Text = "";
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
        }

        private void buscarButton_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void grillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaClientes[0, e.RowIndex].Value == null)
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
                DataGridViewCellCollection celdas = grillaClientes.Rows[e.RowIndex].Cells;
                string clienteADarDeBaja = celdas["Usuario"].Value.ToString();
                if (e.ColumnIndex == celdas["BAJA"].ColumnIndex)
                {
                    if (MessageBox.Show("¿Realmente desea dar de baja a " + clienteADarDeBaja + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            AsistenteUsuario.inhabilitarUsuario(clienteADarDeBaja);
                            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
                        }
                        catch (BajaYaEfectuada)
                        {
                            MessageBox.Show(clienteADarDeBaja+" ya se encontraba dado de baja.");
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
