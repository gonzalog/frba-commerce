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
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.ABM_Rol
{
    public partial class CambiarFunciones : Form
    {
        int rol;

        Dictionary<string,int> funcionesQueQuedarian;
        Dictionary<string, int> lasQueNoQuedarian;
        ModificionRol padre;

        public CambiarFunciones(int rolAModificar, ModificionRol ventanaPadre)
        {
            InitializeComponent();
            this.padre = ventanaPadre;
            rol = rolAModificar;
            this.nombre.Text = AsistenteRol.getNombreRol(rol);

            funcionesQueQuedarian = asociarNombresFunciones(AsistenteRol.getFuncionesDe(rol));
            lasQueNoQuedarian = asociarNombresFunciones(AsistenteRol.getFuncionesNoDe(rol));
            this.actualizarCampos();

            MinimizeBox = false;
            MaximizeBox = false;
        }

        public void actualizarCampos()
        {
            AsistenteBotones.vaciarComboBox(boxParaAgregar);
            AsistenteBotones.vaciarComboBox(boxParaQuitar);
            AsistenteBotones.vaciarListBox(funcionesDelRol);
            cargarFuncionesDelRol();
            cargarFuncionesADarDeAlta();
        }

        public void cargarFuncionesDelRol()
        {
            AsistenteBotones.addListToListBox(funcionesDelRol, funcionesQueQuedarian.Keys.ToList());
            AsistenteBotones.addListToComboBox(boxParaQuitar, funcionesQueQuedarian.Keys.ToList());
        }

        public void cargarFuncionesADarDeAlta()
        {
            AsistenteBotones.addListToComboBox(boxParaAgregar, lasQueNoQuedarian.Keys.ToList());
        }

        private void boxParaQuitar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!AsistenteColecciones.cambiarStringIntDeDict(boxParaQuitar.SelectedItem.ToString(), funcionesQueQuedarian, lasQueNoQuedarian))
            {
                errorBox.Text = "No está la función " + boxParaQuitar.SelectedItem.ToString() + ".";
            }
            else
            {
                errorBox.Text = "Se quitó la función " + boxParaQuitar.SelectedItem.ToString() + ".";
            }
            actualizarCampos();
        }

        private void boxParaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!AsistenteColecciones.cambiarStringIntDeDict(boxParaAgregar.SelectedItem.ToString(), lasQueNoQuedarian, funcionesQueQuedarian))
            {
                errorBox.Text = "No está la función " + boxParaAgregar.SelectedItem.ToString() + ".";
            }
            else
            {
                errorBox.Text = "Se agregó la función " + boxParaAgregar.SelectedItem.ToString() + ".";
            }
            actualizarCampos();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenteRol.cambiarNombre(rol, nombre.Text);
            }
            catch (NombreInvalido expcepcion)
            {
                MessageBox.Show(expcepcion.Message + "Por favor, cámbielo.");
                return;
            }
            AsistenteRol.perdurarFuncionesA(funcionesQueQuedarian.Values.ToList(), lasQueNoQuedarian.Values.ToList(), rol);
            padre.cargarRoles();
            AsistenteVistas.volverAPadreYCerrar(this.padre,this);

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(this.padre, this);
        }

        private Dictionary<string, int> asociarNombresFunciones(List<int> cods) 
        {
            Dictionary<string, int> asociados = new Dictionary<string, int>();
            foreach(int codi in cods)
            {
                asociados.Add(AsistenteRol.getNombreFuncion(codi),codi);
            }
            return asociados;
        }

    }
}
