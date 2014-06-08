using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce
{
    public partial class PantallaPrincipal : Form
    {
        private string user;
        private int rol;
        public Form padre;
        public PantallaPrincipal(string user, int rol,Form padre)
        {
            this.rol = rol;
            this.user = user;
            this.padre = padre;
            InitializeComponent();
            actualizarParaUsuarioYRol();
        }

        private void actualizarParaUsuarioYRol()
        {
            toolStripStatusLabel.Text = "Usuario: " + this.user + " Rol: " + AsistenteRol.getNombreRol(this.rol);
            activarBotonesParaRol();
        }

        private void activarBotonesParaRol()
        {
            List<int> funciones = AsistenteRol.getFuncionesDe(this.rol);
            Dictionary<int,string> nombres = AsistenteRol.getNombresFunciones();
            
            foreach (var boton in tableLayoutPanel.Controls.OfType<Button>())
            {
                if (funciones.Select(cod => nombres[cod]).Contains(boton.Text))
                {
                    boton.Show();
                }
                else
                {
                    boton.Hide();
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentanaYCerrar(new IniciarSesion(),this);
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new CambioPassword.CambioPassword(this.user));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new ABM_Rol.ABMRol(this), this);
        }
    }
}
