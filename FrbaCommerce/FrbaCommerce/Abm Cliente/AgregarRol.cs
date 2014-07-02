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
    public partial class AgregarRol : Form
    {
        public string user;
        public Dictionary<string, int> rolesAjenos;
        public Form padre;
        public AgregarRol(string user, Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.user = user;
            label.Text = label.Text + " " + user;
            AsistenteBotones.hacerNoEditable(comboBox1);
            rolesAjenos = AsistenteRol.getRolesNoDe(user);
            AsistenteBotones.addListToComboBox(comboBox1, rolesAjenos.Keys.ToList());
        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Para asignar un rol debe seleccionarlo.");
                return;
            }

            AsistenteRol.altaRolPorUser(rolesAjenos[comboBox1.Text],user);

            MessageBox.Show("A partir de ahora el usuario "+user+" tiene el rol "+comboBox1.Text+".");
            AsistenteVistas.volverAPadreYCerrar(this.padre,this);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(this.padre, this);
        }
    }
}
