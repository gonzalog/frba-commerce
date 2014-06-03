using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.ABM_Rol
{
    public partial class CambiarFunciones : Form
    {
        int rol;

        public CambiarFunciones(int rolAModificar)
        {
            InitializeComponent();
            rol = rolAModificar;
            this.nombreDelRol.Text = AsistenteRol.getNombreRol(rol);
            
            this.actualizarCampos();
        }

        public void actualizarCampos()
        {
            cargarFuncionesDelRol();
            cargarFuncionesADarDeAlta();
        }

        public void cargarFuncionesDelRol()
        {
            List<int> cods = AsistenteRol.getFuncionesDe(rol);
            List<string> nombres = new List<string>();
            foreach (int cod in cods)
            {
                nombres.Add(AsistenteRol.getNombreFuncion(cod));
            }
            funcionesDelRol.Items.AddRange(nombres.ToArray());

            comboBox1.Items.AddRange(nombres.ToArray());


        }

        public void cargarFuncionesADarDeAlta()
        {
            List<int> codsNoTenidos = AsistenteRol.getFuncionesNoDe(rol);
            List<string> nombresNoTenidos = new List<string>();
            foreach (int cod in codsNoTenidos)
            {
                nombresNoTenidos.Add(AsistenteRol.getNombreFuncion(cod));
            }

            comboBox2.Items.AddRange(nombresNoTenidos.ToArray());
        }

        private void nombreDelRol_Click(object sender, EventArgs e)
        {

        }
    }
}
