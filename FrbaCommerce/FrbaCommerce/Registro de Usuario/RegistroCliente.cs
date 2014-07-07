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

namespace FrbaCommerce.Login
{
    public partial class RegistroCliente : Form
    {
        public Form padre;
        public RegistroCliente(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            elecTipoDoc.Items.Add("DNI");
            elecTipoDoc.Items.Add("LE");
            elecTipoDoc.Items.Add("LC");
            eleccionPassword.PasswordChar = confirContraseña.PasswordChar = '*';
            elecTipoDoc.ReadOnly = true;

            AsistenteBotones.hacerNoEditable(elecTipoDoc);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar? Se perderan todos los datos cargados.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AsistenteVistas.volverAPadreYCerrar(padre,this);
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            errorBox.Text = "Evaluando solicitud...";
            List<string> errores = new List<string>();

            try
            {
                AsistenteUsuario.userNameValido(eleccionUsername.Text, errores);
                AsistenteUsuario.contraseñaValida(eleccionPassword.Text, confirContraseña.Text, errores);

                AsistenteBotones.chequearTextboxNoNulo(elecNombre, errores, "Nombre");
                AsistenteBotones.chequearTextboxNoNulo(elecApe, errores, "Apellido");
                AsistenteBotones.chequearTextboxNoNulo(elecNroDoc, errores, "Número documento");
                AsistenteCliente.chequearTipoYNroDocNoRepetido(elecTipoDoc.Text, elecNroDoc.Text, errores);
                AsistenteBotones.chequearTextboxNoNuloYMail(elecEMail, errores, "E-Mail");
                AsistenteBotones.chequearTextboxNoNuloYTelCliente(elecTelefono, errores, "Número de teléfono");
                AsistenteBotones.chequearTextboxNoNulo(elecCalle, errores, "Calle");
                AsistenteBotones.chequearTextboxNoNulo(elecNumero, errores, "Número de calle");
                AsistenteBotones.chequearTextboxNoNulo(elecPiso, errores, "Piso");
                AsistenteBotones.chequearTextboxNoNulo(elecDepartamento, errores, "Departamento");
                AsistenteBotones.chequearTextboxNoNulo(elecLocalidad, errores, "Localidad");
                AsistenteBotones.chequearTextboxNoNulo(elecCP, errores, "Código postal");
            }
            catch (ElTamanioDeLosDatosExcedeAlSistema muchoTamanio)
            {
                MessageBox.Show(muchoTamanio.Message);
                return;
            }
            catch (HayCamposEnBlanco hayBlancos)
            {
                MessageBox.Show(hayBlancos.Message);
                return;
            }


            if (errores.Count() > 0)
            {
                errorBox.Text = "Registro rechazado.";
                MessageBox.Show(AsistenteBotones.hacerListadoErrores(errores));
                return;
            }
            else
            {
                errorBox.Text = "Registro aceptado.";
                AsistenteCliente.altaCliente(eleccionUsername.Text,
                                            eleccionPassword.Text,
                                            1,
                                            "Cliente",
                                            elecNombre.Text,
                                            elecApe.Text,
                                            elecTipoDoc.Text,
                                            elecNroDoc.Text,
                                            elecEMail.Text,
                                            elecTelefono.Text,
                                            elecCalle.Text,
                                            elecNumero.Text,
                                            elecPiso.Text,
                                            elecDepartamento.Text,
                                            elecLocalidad.Text,
                                            elecCP.Text,
                                            elecFechaNac.Value.Date
                                            );
                MessageBox.Show("Usuario creado con éxito.\n¡Bienvenido "+eleccionUsername.Text+" a FRBA-Commerce!");
                AsistenteVistas.mostrarNuevaVentana(new PantallaPrincipal(eleccionUsername.Text,AsistenteRol.getCodRol("Cliente"), padre), this);
            }
        }

        private void elecNroDoc_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNroDoc);
        }

        private void elecTelefono_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecTelefono);
        }

        private void elecNumero_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNumero);
        }

        private void elecPiso_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecPiso);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }    
    }
}
