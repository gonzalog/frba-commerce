using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.ABM_Rol
{
    public partial class ModificionRol : Form
    {
        public Form padre;

        public ModificionRol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            AsistenteVistas.CargarGrilla(grillaRoles, AsistenteRol.getRoles());
            cargarBotonCambiarFunciones();

            MinimizeBox = false;
            MaximizeBox = false;
        }

        public void cargarRoles()
        {
            AsistenteVistas.CargarGrilla(grillaRoles, AsistenteRol.getRolesBuscando(nombreBox.Text));
        }

        private void cargarBotonCambiarFunciones()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "EDITAR";
            col.Name = "EDITAR";
            col.UseColumnTextForButtonValue = true;
            grillaRoles.Columns.Add(col);
        }

        private void ListadoRoles_Activated(object sender, EventArgs e)
        {
            cargarRoles();
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void buscarButton_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.CargarGrilla(grillaRoles,AsistenteRol.getRolesBuscando(nombreBox.Text));
        }

        private void limpiarButton_Click_1(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            cargarRoles();
        }

        private void ModificionRol_Load(object sender, EventArgs e)
        {

        }

        private void grillaRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaRoles[0, e.RowIndex].Value == null)
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
               int rolAModificar = Convert.ToInt32(grillaRoles.Rows[e.RowIndex].Cells["cod_rol"].Value.ToString());
               if (e.ColumnIndex == grillaRoles.Rows[e.RowIndex].Cells["EDITAR"].ColumnIndex)
               {
                   AsistenteVistas.mostrarNuevaVentana((new CambiarFunciones(rolAModificar, this)), this);
               }
            }
            catch (ArgumentOutOfRangeException) 
            {
                errorBox.Text = "Click inválido.";
            }
        }
    }
}
