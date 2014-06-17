using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class MuestraHistorial : Form
    {
        public delegate DataTable traerTabla();
        public MuestraHistorial(traerTabla delegado)
        {
            InitializeComponent();
            AsistenteVistas.CargarGrilla(dataGridView1,delegado());
        }
    }
}
