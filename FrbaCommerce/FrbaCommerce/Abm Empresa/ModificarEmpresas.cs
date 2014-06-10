using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class ModificarEmpresas : Form
    {
        public Form padre;
        public ModificarEmpresas(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando("", "", ""));
            cargarBotonModificarDatos();
        }

        private void cargarBotonModificarDatos()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "EDITAR";
            col.Name = "MODIFICAR DATOS";
            col.UseColumnTextForButtonValue = true;
            grillaEmpresas.Columns.Add(col);
        }

        private void elecNroDoc_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericosOGuion(elecCUIT);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            TextBox[] filtros = new TextBox[3] { elecRS, elecCUIT, elecEMail };
            foreach (TextBox filtro in filtros) filtro.Text = "";
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando("","",""));
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaEmpresas, AsistenteEmpresa.getTableBuscando(elecRS.Text,elecCUIT.Text, elecEMail.Text));
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
                string empresaAModificar = celdas["Usuario"].Value.ToString();
                if (e.ColumnIndex == celdas["MODIFICAR DATOS"].ColumnIndex)
                {
                    AsistenteVistas.mostrarNuevaVentana((new EditarEmpresa(empresaAModificar, this)), this);
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
