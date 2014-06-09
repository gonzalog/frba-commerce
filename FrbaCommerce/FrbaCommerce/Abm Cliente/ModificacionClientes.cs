using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ModificacionClientes : Form
    {
        public Form padre;
        public ModificacionClientes(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            boxTipoDoc.Items.Add("DNI");
            boxTipoDoc.Items.Add("LE");
            boxTipoDoc.Items.Add("LC");
            boxTipoDoc.Items.Add("");
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text,elecApe.Text,boxTipoDoc.Text,elecNroDoc.Text,elecEMail.Text));
            cargarBotonModificarDatos();
            boxTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargarBotonModificarDatos()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "EDITAR";
            col.Name = "EDICIÓN";
            col.UseColumnTextForButtonValue = true;
            grillaClientes.Columns.Add(col);
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            elecApe.Text = "";
            boxTipoDoc.Text = "";
            elecNroDoc.Text = "";
            elecEMail.Text = "";
            AsistenteVistas.CargarGrilla(grillaClientes, AsistenteCliente.getTableBuscando(nombreBox.Text, elecApe.Text, boxTipoDoc.Text, elecNroDoc.Text, elecEMail.Text));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
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
                string clienteAModificar = celdas["Usuario"].Value.ToString();
                if (e.ColumnIndex == celdas["EDICIÓN"].ColumnIndex)
                {
                    AsistenteVistas.mostrarNuevaVentana((new EditarCliente(clienteAModificar, this)), this);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }
        }

    }
}
