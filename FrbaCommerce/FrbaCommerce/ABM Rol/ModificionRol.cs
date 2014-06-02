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
        public int rolAModificar;
        DataTable rolesExistentes;

        public ModificionRol(Form padre, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent();
            this.pantallaPrincipal = pantallaPrincipal;
            this.padre = padre;
            rolesExistentes = AsistenteRol.getRoles();
            cargarRoles();
            cargarBotonFuncionalidad();    
        }

        public void cargarRoles()
        {
            AsistenteVistas.CargarGrilla(grillaRoles, rolesExistentes);
        }

        private void cargarBotonFuncionalidad()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Rol";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaRoles.Columns.Add(col);
        }

        private bool estaDadoDeBaja(DataGridViewRow fila)
        {
            int index = grillaRoles.Columns["Habilitado"].Index;
            return !(bool)fila.Cells[index].Value;
        }

        private void ListadoRoles_Activated(object sender, EventArgs e)
        {
            cargarRoles();
        }

        /*
        private int  crearRol(int fila)
        {
            Rol rol = new Rol();
            int index = grillaRoles.Columns["ID Rol"].Index;
            rol.id = Convert.ToInt32(grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString());
            index = grillaRoles.Columns["Nombre"].Index;
            rol.nombre = grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString();
            index = grillaRoles.Columns["Habilitado"].Index;
            rol.habilitado = Convert.ToBoolean(grillaRoles.Rows.SharedRow(fila).Cells[index].Value.ToString());
            return rol;
        }*/
        
        private void grillaRoles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {/*
            if (e.ColumnIndex == grillaRoles.Columns["Seleccionar"].Index && e.RowIndex >= 0 && e.RowIndex < (grillaRoles.Rows.Count - 1)) //Para que la accion de click sea valida solo sobre el boton
            {
                DataGridViewRow fila = grillaRoles.Rows[e.RowIndex];

                Rol rol = crearRol(e.RowIndex); //instancia un afiliado y luego depende de la funcionalidad, abrirá otra ventana
                if (funcion == "Baja")
                {
                    if (!estaDadoDeBaja(fila))
                    {
                        AsistenteVistas.mostrarNuevaVentana(new Baja_Rol(this, rol), this);
                    }
                    else
                    {
                        MessageBox.Show("El Rol seleccionado ya se encuentra inhabilitado");
                    }
                }
                if (funcion == "Modificar") AsistenteVistas.mostrarNuevaVentana(new Modificar_Rol2(this, rol, pantallaPrincipal), this);
                //en modificar no muestro la ventana de error si esta dado de baja, porque se puede volver a habilitar
            }*/
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void buscarButton_Click_1(object sender, EventArgs e)
        {
            rolesExistentes = AsistenteRol.getRolesBuscando(nombreBox.Text);
            cargarRoles();
        }

        private void limpiarButton_Click_1(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            rolesExistentes = AsistenteRol.getRoles();
            cargarRoles();
        }

    }
}
