using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Login;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroEmpresa : Form
    {
        Form padre;
        public RegistroEmpresa(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            eleccionRol.Items.AddRange(AsistenteRol.getNombresRolesHabilitados());
            eleccionPassword.PasswordChar = '*';
            eleccionRol.ReadOnly = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar? Se perderan todos los datos cargados.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AsistenteVistas.volverAPadreYCerrar(padre, this);
            }
        }

        private void elecTelefono_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecTelefono);
        }

        private void elecCUIT_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecCUIT);
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

            AsistenteUsuario.userNameValido(eleccionUsername.Text, errores);
            AsistenteUsuario.contraseñaValida(eleccionPassword.Text, errores);
            AsistenteRol.rolValido(eleccionRol.Text, errores);

            AsistenteBotones.chequearTextboxNoNulo(elecRazonSocial, errores, "Nombre");
            AsistenteBotones.chequearTextboxNoNuloYMail(elecEMail, errores, "E-Mail");
            AsistenteBotones.chequearTextboxNoNulo(elecTelefono, errores, "Número de teléfono");
            AsistenteBotones.chequearTextboxNoNulo(elecCiudad, errores, "Ciudad");
            AsistenteBotones.chequearTextboxNoNulo(elecCUIT, errores, "CUIT");
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
                AsistenteEmpresa.altaEmpresa(eleccionUsername.Text,
                                            eleccionPassword.Text,
                                            eleccionRol.Text,
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
                                            elecCUIT.Text,
                                            elecNombreContacto.Text,
                                            elecFechaCreacion.Value.Date
                                            );
                MessageBox.Show("Usuario creado con éxito.\n¡Bienvenido " + eleccionUsername.Text + " a FRBA-Commerce!");
                AsistenteVistas.mostrarNuevaVentana(new ElegirRol(eleccionUsername.Text, this), this);
            }
        }
    }
}
