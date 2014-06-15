using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class verRespuesta : Form
    {
        private Form padre;

        public verRespuesta(int codigoPubli,int pregunta,string descripcionDeLaPregunta,Form padre)
        {
            System.Diagnostics.Debug.WriteLine("Se ingresa a construir verRespuesta.");
            InitializeComponent();
            this.padre = padre;

            laPregunta.Text = descripcionDeLaPregunta;
            Publicacion publicacion = new Publicacion(codigoPubli);
            System.Diagnostics.Debug.WriteLine("Se instacia la publicacion.");

            idPubli.Text = publicacion.id.ToString();
            descrip.Text = publicacion.descripcion;
            System.Diagnostics.Debug.WriteLine("Se pide al tipo su nombre.");
            tipo.Text = publicacion.tipo.nombreTipo();
            System.Diagnostics.Debug.WriteLine("Se pide al estado su nombre.");
            estado.Text = publicacion.estado.nombre();
            stock.Text = publicacion.tipo.stock.ToString();
            precIni.Text = publicacion.tipo.precioInicial.ToString();
            System.Diagnostics.Debug.WriteLine("Se pide al tipo su precio actual.");
            precActual.Text = publicacion.tipo.precioActual().ToString();

            System.Diagnostics.Debug.WriteLine("Se pide la respuesta a la pregunta.");
            respuesta.Text = AsistentePreguntas.getDescripcionRespuesta(pregunta);

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }
    }
}
