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
        PantallaPrincipal pantallaPrincipal;

        public ModificionRol(Form padre, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent();
            this.pantallaPrincipal = pantallaPrincipal;
            this.padre = padre;
            cargarRoles();
            cargarBotonCambiarFunciones();
            cargarBotonHabilitacion();
        }

        public void cargarRoles()
        {
            DataTable rolesExistentes = AsistenteRol.getRoles();
            AsistenteVistas.CargarGrilla(grillaRoles, rolesExistentes);
        }

        private void cargarBotonCambiarFunciones()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Cambiar funciones";
            col.Name = "Funciones";
            col.UseColumnTextForButtonValue = true;
            grillaRoles.Columns.Add(col);
        }

        private void cargarBotonHabilitacion()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Name = "Habilitar";
            col.Text = "BAJA-ALTA";
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
            int rolAModificar = Convert.ToInt32(grillaRoles.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("Se desea cambiar funciones del rol " + grillaRoles.Rows[e.RowIndex].Cells[3].Value.ToString()+" .");

                AsistenteVistas.mostrarNuevaVentana((new CambiarFunciones(rolAModificar,this)), this);

            }
            if (e.ColumnIndex == 1) 
            {
                DataGridViewCellCollection filaDelRol = grillaRoles.Rows[e.RowIndex].Cells;
                string nombreRolACambiar = filaDelRol[3].Value.ToString();
                if (AsistenteRol.rolHabilitado(rolAModificar)) 
                {
                    AsistenteVistas.mostrarNuevaVentana((new ConfirmarInhabilitacion(rolAModificar, nombreRolACambiar)), this);
                }
                else
                {
                    AsistenteRol.habilitarRol(rolAModificar);
                    MessageBox.Show("Se habilitó el rol "+nombreRolACambiar+".");
                    cargarRoles();
                }
            }
        }

        private void errorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
