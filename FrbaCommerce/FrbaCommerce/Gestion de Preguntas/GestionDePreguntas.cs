﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class GestionDePreguntas : Form
    {
        string user;

        public GestionDePreguntas(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void responderPreguntas_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new listadoPreguntas(
                delegate(int publicacion,int pregunta, string descripcionDeLaPregunta, Form padre)
                {
                    System.Diagnostics.Debug.WriteLine("Se cliqueó el botón.");
                    return new responderPregunta(pregunta, descripcionDeLaPregunta, padre);
                },
                delegate(DataGridView grilla, string busqueda, string user)
                {
                    AsistenteVistas.CargarGrilla(grilla, AsistenteUsuario.getPregsParaBuscando(busqueda, user));
                },
                delegate(DataGridView grilla) 
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.Text = "RESPONDER";
                    col.Name = "DESEO";
                    col.UseColumnTextForButtonValue = true;
                    grilla.Columns.Add(col);
                },
                this.user), this);
        }

        private void verRespuestas_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new listadoPreguntas(
                delegate(int publicacion, int pregunta, string descripcionDeLaPregunta, Form padre)
                {
                    System.Diagnostics.Debug.WriteLine("Se cliqueó el botón.");
                    return new verRespuesta(publicacion,pregunta, descripcionDeLaPregunta, padre);
                },
                delegate(DataGridView grilla, string busqueda, string user)
                {
                    AsistenteVistas.CargarGrilla(grilla, AsistenteUsuario.getPregsRespondidasBuscando(busqueda, user));
                },
                delegate(DataGridView grilla)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.Text = "VER RESPUESTA";
                    col.Name = "DESEO";
                    col.UseColumnTextForButtonValue = true;
                    grilla.Columns.Add(col);
                },
                this.user), this);
        }
    }
}
