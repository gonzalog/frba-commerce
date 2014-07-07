using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Abm_Cliente;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class EditarEmpresa : Form
    {
        public Form padre;
        public Empresa empresa;
        public EditarEmpresa(string user,Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.empresa = AsistenteEmpresa.newEmpresa(user);
            setearValoresDefault();
            nuevoRol.Text = nuevoRol.Text + user;
        }

        private void setearValoresDefault()
        {
            elecRazonSocial.Text = empresa.razon;
            elecEMail.Text = empresa.mail;
            elecTelefono.Text = empresa.telefono;
            elecCiudad.Text = empresa.ciudad;
            elecCUIT.Text = empresa.cuit;
            elecNombreContacto.Text = empresa.nombreDeContacto;
            elecFechaCreacion.Value = empresa.fechaCreacion;

            Direccion direccion = empresa.direccion;
            elecCalle.Text = direccion.calle;
            elecNumero.Text = direccion.numero.ToString();
            elecPiso.Text = direccion.piso.ToString();
            elecDepartamento.Text = direccion.depto;
            elecLocalidad.Text = direccion.localidad;
            elecCP.Text = direccion.codPostal;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AsistenteVistas.nombreProyecto + "\n" + "Desarrollado por THE_DISCRETABOY");
        }

        private void elecRazonSocial_TextChanged(object sender, EventArgs e)
        {
            empresa.razon = elecRazonSocial.Text;
        }

        private void elecEMail_TextChanged(object sender, EventArgs e)
        {
            empresa.mail = elecEMail.Text;
        }

        private void elecTelefono_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecTelefono);
            empresa.telefono = elecTelefono.Text;
        }

        private void elecCiudad_TextChanged(object sender, EventArgs e)
        {
            empresa.ciudad = elecCiudad.Text;
        }

        private void elecCUIT_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericosOGuion(elecCUIT);
            empresa.cuit = elecCUIT.Text;
        }

        private void elecNombreContacto_TextChanged(object sender, EventArgs e)
        {
            empresa.nombreDeContacto = elecNombreContacto.Text;
        }

        private void elecFechaCreacion_ValueChanged(object sender, EventArgs e)
        {
            empresa.fechaCreacion = elecFechaCreacion.Value;
        }

        private void elecCalle_TextChanged(object sender, EventArgs e)
        {
            empresa.direccion.calle = elecCalle.Text;
        }

        private void elecNumero_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNumero);
            try
            {
                empresa.direccion.numero = Convert.ToInt64(elecNumero.Text);
            }
            catch (Exception)
            {
                empresa.direccion.numero = 0;
            }
        }

        private void elecPiso_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecPiso);
            try
            {
                empresa.direccion.piso = Convert.ToInt64(elecPiso.Text);
            }
            catch (Exception)
            {
                empresa.direccion.piso = 0;
            }
        }

        private void elecDepartamento_TextChanged(object sender, EventArgs e)
        {
            empresa.direccion.depto = elecDepartamento.Text;
        }

        private void elecLocalidad_TextChanged(object sender, EventArgs e)
        {
            empresa.direccion.localidad = elecLocalidad.Text;
        }

        private void elecCP_TextChanged(object sender, EventArgs e)
        {
            empresa.direccion.codPostal = elecCP.Text;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre, this);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer realizar estos cambios?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.empresa.perdurar();
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
                catch (CUITRepetido)
                {
                    MessageBox.Show("Tal CUIT ya se encuentra registrado en el sistema.");
                }
                catch (TelefonoYaRegistrado)
                {
                    MessageBox.Show("El teléfono ingresado ya se encuentra registrado en el sistema.");
                }
            } 
        }

        private void nuevoRol_Click(object sender, EventArgs e) 
        //Esta funcionalidad fue descartada de acuerdo con lo indicado en el grupo.
        {
            AsistenteVistas.mostrarNuevaVentana(new AgregarRol(empresa.user, this), this);
        }
    }
}
