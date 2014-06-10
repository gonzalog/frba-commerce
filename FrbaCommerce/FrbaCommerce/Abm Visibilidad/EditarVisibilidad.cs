using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class EditarVisibilidad : Form
    {
        public Form padre;
        public Visibilidad visi;
        public EditarVisibilidad(int codVisi,Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.visi = AsistenteVisibilidad.newVisibilidad(codVisi);
            codNum.Text = codVisi.ToString();
            setearValoresDefault();
        }
        private void setearValoresDefault()
        {
            elecDescrip.Text = visi.descripcion;
            elecPrec.Text = visi.precio;
            elecPorcen.Text = visi.porcentaje;
        }

        private void elecDescrip_TextChanged(object sender, EventArgs e)
        {
            visi.descripcion = elecDescrip.Text;
        }

        private void elecPrec_TextChanged(object sender, EventArgs e)
        {
            //AsistenteBotones.checkSoloNumericos(elecPrec);
            visi.precio = elecPrec.Text;
        }

        private void elecPorcen_TextChanged(object sender, EventArgs e)
        {
           // AsistenteBotones.checkSoloNumericos(elecPorcen);
            visi.porcentaje = elecPorcen.Text;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer realizar estos cambios?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.visi.perdurar();
                    this.Close();
                }
                catch (HayCamposEnBlanco)
                {
                    MessageBox.Show("La operación no puede concretarse porque hay campos en blanco.");
                }
                catch (ElTamanioDeLosDatosExcedeAlSistema)
                {
                    MessageBox.Show("El tamaño de los datos ingresados excede las capacidades del sistema.");
                }
            } 
        }
    }
}
