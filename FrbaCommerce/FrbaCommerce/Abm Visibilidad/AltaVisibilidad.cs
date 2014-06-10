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
    public partial class AltaVisibilidad : Form
    {
        private Form padre;
        public AltaVisibilidad(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecCodigo);
        }

        private void elecPrec_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecPrec);
        }

        private void elecPorcen_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericosYMenorOIgualA(elecPorcen,100);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenteBotones.chequearTextboxNoNulo(elecCodigo, "Código");
                AsistenteBotones.chequearTextboxNoNulo(elecDescrip, "Descripción");
                AsistenteBotones.chequearTextboxNoNulo(elecDescrip, "Precio por publicar");
                AsistenteBotones.chequearTextboxNoNulo(elecDescrip, "% de la venta");
            }
            catch (HayCamposEnBlanco ex)
            {
                MessageBox.Show(ex.Message); 
                return;
            }
            
            int codigo;
            try
            {
                codigo = Convert.ToInt32(elecCodigo.Text);
                AsistenteVisibilidad.chequearCodigoUnico(codigo);
            }
            catch (CodigoRepetido ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch(Exception)
            {
                MessageBox.Show("El valor ingresado en el campo código no es soportado por el sistema.");
                return;
            }
            
            
            Double precio,porcentaje;
            try
            {
                precio = Convert.ToDouble(elecPrec.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("El valor ingresado en el campo precio no es soportado por el sistema.");
                return;
            }
            try
            {
                porcentaje = Convert.ToDouble(elecPorcen.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("El valor ingresado en el campo porcentaje no es soportado por el sistema.");
                return;
            }
            try
            {
                AsistenteVisibilidad.altaVisibilidad(codigo, elecDescrip.Text, precio, porcentaje);
                MessageBox.Show(elecDescrip.Text+" fue dado de alta exitosamente.");
                AsistenteVistas.volverAPadreYCerrar(padre,this);
            }
            catch (FallaDelMotor ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
