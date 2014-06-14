using System;
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
    public partial class listadoPreguntas : Form
    {
        private string user;
        public delegate Form RespuestaBoton(int pregunta,Form padre);
        public delegate void CargadorGrilla(DataGridView grilla,string busqueda,string usuario);
        public delegate void AgregadorDeBoton(DataGridView grilla);
        private RespuestaBoton abrirVentana;
        private CargadorGrilla cargadorGrilla;
        private AgregadorDeBoton agregadorBoton;

        public listadoPreguntas(RespuestaBoton delegateBoton,CargadorGrilla delegateCargador,
            AgregadorDeBoton agregadorBoton ,string user)
        {
            InitializeComponent();
            this.abrirVentana = delegateBoton;
            this.cargadorGrilla = delegateCargador;
            this.agregadorBoton = agregadorBoton;
            this.user = user;

            this.cargadorGrilla(grillaPregs,"",this.user);
            this.agregadorBoton(grillaPregs);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.cargadorGrilla(grillaPregs,buscador.Text,this.user);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            buscador.Text = "";
            this.cargadorGrilla(grillaPregs, "", this.user);
        }

        private void grillaPregs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaPregs[0, e.RowIndex].Value == null)
                {
                    errorBox.Text = "Click inválido.";
                    return;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
                return;
            }
            try
            {
                int pregAResponder = Convert.ToInt32(grillaPregs.Rows[e.RowIndex].Cells["CODIGO PREGUNTA"].Value.ToString());
                if (e.ColumnIndex == grillaPregs.Rows[e.RowIndex].Cells["DESEO"].ColumnIndex)
                {
                    System.Diagnostics.Debug.WriteLine("Se clickeó para responder a: "+pregAResponder);
                    AsistenteVistas.mostrarNuevaVentana(this.abrirVentana(pregAResponder,this),this);      
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                errorBox.Text = "Click inválido.";
            }
        }
    }
}
