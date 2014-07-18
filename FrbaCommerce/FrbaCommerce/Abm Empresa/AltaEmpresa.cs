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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class AltaEmpresa : Form
    {
        public Form padre;
        public AltaEmpresa(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar? Se perderan todos los datos cargados.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void elecTelefono_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecTelefono);
        }

        private void elecCUIT_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecCUIT1);
        }

        private void elecNumero_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNumero);
        }

        private void elecPiso_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecPiso);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            errorBox.Text = "Evaluando solicitud...";
            List<string> errores = new List<string>();
            try
            {
                System.Diagnostics.Debug.WriteLine("Se comienza a checkear");
                System.Diagnostics.Debug.WriteLine("Se chequea el cuit: " + elecCUIT1.Text + elecCUIT2.Text + elecCUIT3.Text);
                AsistenteEmpresa.chequearTextboxNoNuloYCUIT(elecCUIT1, elecCUIT2, elecCUIT3, errores);
                System.Diagnostics.Debug.WriteLine("Se pasa el checkeo del cuit: " + 
                    elecCUIT1.Text + elecCUIT2.Text + elecCUIT3.Text);
                AsistenteEmpresa.chequearTextboxNoNuloYRSUnica(elecRazonSocial, errores, "Razón Social");

                AsistenteBotones.chequearTextboxNoNuloYMail(elecEMail, errores, "E-Mail");
                AsistenteBotones.chequearTextboxNoNulo(elecTelefono, errores, "Número de teléfono");
                AsistenteBotones.chequearTextboxNoNulo(elecCiudad, errores, "Ciudad");
                AsistenteBotones.chequearTextboxNoNulo(elecNombreContacto, errores, "Nombre de contacto");
                AsistenteBotones.chequearTextboxNoNulo(elecCalle, errores, "Calle");
                AsistenteBotones.chequearTextboxNoNulo(elecNumero, errores, "Número de calle");
                AsistenteBotones.chequearTextboxNoNulo(elecPiso, errores, "Piso");
                AsistenteBotones.chequearTextboxNoNulo(elecDepartamento, errores, "Departamento");
                AsistenteBotones.chequearTextboxNoNulo(elecLocalidad, errores, "Localidad");
                AsistenteBotones.chequearTextboxNoNulo(elecCP, errores, "Código postal");

                if (errores.Count() > 0)
                {
                    errorBox.Text = "Registro rechazado.";
                    MessageBox.Show(AsistenteBotones.hacerListadoErrores(errores));
                    return;
                }
                else
                {
                    errorBox.Text = "Registro aceptado.";
                    AsistenteEmpresa.altaEmpresa(
                                                elecRazonSocial.Text,
                                                "UTNFRBA",
                                                0,
                                                "Empresa",
                                                elecRazonSocial.Text,
                                                elecEMail.Text,
                                                elecTelefono.Text,
                                                elecCalle.Text,
                                                elecNumero.Text,
                                                elecPiso.Text,
                                                elecDepartamento.Text,
                                                elecLocalidad.Text,
                                                elecCP.Text,
                                                elecCiudad.Text,
                                                elecCUIT1.Text + "-" + elecCUIT2.Text + "-" + elecCUIT3.Text,
                                                elecNombreContacto.Text,
                                                elecFechaCreacion.Value.Date
                                                );
                    MessageBox.Show("Se incluyó a " + elecRazonSocial.Text + " a FRBA-Commerce exitosamente.");
                    AsistenteVistas.volverAPadreYCerrar(padre, this);
                }
            }
            catch (ElTamanioDeLosDatosExcedeAlSistema ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecCUIT2);
        }

        private void elecCUIT3_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecCUIT3);
        }
    }
}
