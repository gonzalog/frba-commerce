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
    public partial class responderPregunta : Form
    {
        public int pregunta;
        private Form padre;
        public responderPregunta(int pregunta,string descripcionDeLaPregunta,Form padre)
        {
            InitializeComponent();
            this.pregunta = pregunta;
            this.padre = padre;

            titulo.Text = descripcionDeLaPregunta;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar? Se perderá la respuesta.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (respuesta.Text.Equals(""))
            {
                MessageBox.Show("La respuesta no puede estar vacía.");
                return;
            }
            if(respuesta.Text.Length>=255)
            {
                MessageBox.Show("La respuesta excede el límite de 255 caracteres.");
                return;
            }
            AsistentePreguntas.perdurarRespuesta(pregunta, respuesta.Text);
            MessageBox.Show("La respuesta ha sido guardada. Gracias.");
            Close();
        }
    }
}
