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
    public partial class AltaRol : Form
    {
        private Form padre;
        Dictionary<int, string> funciones;
        string nombreDelRol;

        public AltaRol(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            cargarNombresFunciones();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void cargarNombresFunciones()
        {
            funciones = AsistenteRol.getNombresFunciones();
            Console.WriteLine("Hay "+funciones.Count()+" funciones cargadas");
            foreach (KeyValuePair<int, string> entry in funciones)
            {
                checkedListBox1.Items.Add(entry.Value);
            }
        }

        private List<int> encontrarFuncionesElegidas()
        {
            List<int> funcionesElegidas = new List<int>();

            foreach (string funcion in checkedListBox1.CheckedItems)
            {
                int codigoFuncion = getIdFuncion(funcion);
                funcionesElegidas.Add(codigoFuncion);
            }
            Console.WriteLine("Seleccionaste " + funcionesElegidas.Count + " funciones.");
            return funcionesElegidas;
        }


        private int getIdFuncion(string nombre)
        {
            return funciones.First((KeyValuePair<int, string> f)=>f.Value == nombre).Key;
        }

        private void inicializarCampos()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
           
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nombreDelRol = textBox1.Text;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            List<int> funcionesElegidas = encontrarFuncionesElegidas();
            int codNuevo = AsistenteRol.altaRol(nombreDelRol, 1, funcionesElegidas);
            MessageBox.Show("El alta del rol se ha realizado con éxito.\n\nDetalle:\nId: " + codNuevo + "\nRol: " + nombreDelRol);
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void Limpiar_Click_1(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

     }
}
