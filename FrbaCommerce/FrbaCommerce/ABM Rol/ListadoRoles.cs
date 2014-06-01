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
    public partial class ListadoRoles : Form
    {
        public Form padre;
        PantallaPrincipal pantallaPrincipal;
        public string funcion;

        public ListadoRoles(Form padre, PantallaPrincipal pantallaPrincipal)
        {
            InitializeComponent();
            this.pantallaPrincipal = pantallaPrincipal;
            this.padre = padre;
            cargarGrilla();
            cargarBotonFuncionalidad();
        }

        public void cargarGrilla()
        {
            AsistenteVistas.CargarGrilla(grillaRoles, AsistenteRol.getRoles());
        }

        private void cargarBotonFuncionalidad() //esto cargaria el boton en la grilla
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Text = "Seleccionar Rol";
            col.Name = "Seleccionar";
            col.UseColumnTextForButtonValue = true;
            grillaRoles.Columns.Add(col);
        }

    }
}
