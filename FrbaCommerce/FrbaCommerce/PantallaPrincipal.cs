﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Gestion_de_Preguntas;
using FrbaCommerce.Comprar_Ofertar;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.Historial_Cliente;
using FrbaCommerce.Facturar_Publicaciones;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Listado_Estadistico;

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
                    boton.Cursor = Cursors.Hand;
                }
                else
                {
                    boton.Hide();
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(this.padre,this);
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new CambioPassword.CambioPassword(this.user));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new ABM_Rol.ABMRol(this));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new ABMCliente(this));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new ABMEmpresa());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new ABMVisibilidad());
        }

        private void publicar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new GenerarPublicacion(this.user));
        }

        private void editarPublicacion_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new VerPublicacionesAEditar(this.user));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new GestionDePreguntas(this.user));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Adquisicion> pendientes = AsistenteCliente.packComprasACalificar(user,0);
            System.Diagnostics.Debug.WriteLine("Se comienza a buscar calificaciones pendientes.");
            if (pendientes.Count > 4)
            {
                MessageBox.Show("Para poner comprar/ofertar necesita efectuar las calificaciones pendiente.");
            }
            else
            {
                AsistenteVistas.mostrarNuevaVentana(new ComprarOfertar(this.user,this),this);
            }
            return;
        }

        private void calificar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new Calificar(user));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new Historial(user));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura(user);
            try
            {
                AsistenteVistas.mostrarSimultaneo(new SiguienteARendir(factura,0));
            }
            catch (NoHayMasParaFacturar)
            {
                MessageBox.Show("Usted no tiene publicaciones por facturar.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarSimultaneo(new SeleccionDeListado());
        }
    }
}
