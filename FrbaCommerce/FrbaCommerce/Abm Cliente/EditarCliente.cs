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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class EditarCliente : Form
    {
        public Form padre;
        public Cliente cliente;
        public EditarCliente(string usuarioDelCliente,Form padre)
        {
            InitializeComponent();
            this.padre = padre;
            this.cliente = AsistenteCliente.newCliente(usuarioDelCliente);
            setearValoresDefault();
            nuevoRol.Text = nuevoRol.Text + usuarioDelCliente;
        }

        private void setearValoresDefault()
        {
            elecNombre.Text = cliente.nombre;
            elecApe.Text = cliente.apellido;
            elecTipoDoc.Text = cliente.tipoDoc;
            elecNroDoc.Text = cliente.nroDoc;
            elecEMail.Text = cliente.mail;
            elecTelefono.Text = cliente.telefono;
            elecFechaNac.Value = cliente.fechaNac;

            Direccion direccion = cliente.direccion;
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

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer realizar estos cambios?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.cliente.perdurar();
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
                catch (DocumentoRepetido)
                {
                    MessageBox.Show("Tal número y tipo de documento ya se encuentran registrados en el sistema.");
                }
                catch (TelefonoYaRegistrado)
                {
                    MessageBox.Show("El teléfono ingresado ya se encuentra registrado en el sistema.");
                }
            }        
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            AsistenteVistas.volverAPadreYCerrar(padre,this);
        }

        private void elecNombre_TextChanged(object sender, EventArgs e)
        {
            cliente.nombre = elecNombre.Text;
        }

        private void elecApe_TextChanged(object sender, EventArgs e)
        {
            cliente.apellido = elecApe.Text;
        }

        private void elecTipoDoc_SelectedItemChanged(object sender, EventArgs e)
        {
            cliente.tipoDoc = elecTipoDoc.Text;
        }

        private void elecNroDoc_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNroDoc);
            cliente.nroDoc = elecNroDoc.Text;
        }

        private void elecEMail_TextChanged(object sender, EventArgs e)
        {
            cliente.mail = elecEMail.Text;
        }

        private void elecTelefono_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecTelefono);
            cliente.telefono = elecTelefono.Text;
        }

        private void elecFechaNac_ValueChanged(object sender, EventArgs e)
        {
            cliente.fechaNac = elecFechaNac.Value;
        }

        private void elecCalle_TextChanged(object sender, EventArgs e)
        {
            cliente.direccion.calle = elecCalle.Text;
        }

        private void elecNumero_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecNumero);
            cliente.direccion.numero = Convert.ToInt64(elecNumero.Text);
        }

        private void elecPiso_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(elecPiso);
            cliente.direccion.piso = Convert.ToInt64(elecPiso.Text);
        }

        private void elecDepartamento_TextChanged(object sender, EventArgs e)
        {
            cliente.direccion.depto = elecDepartamento.Text;
        }

        private void elecLocalidad_TextChanged(object sender, EventArgs e)
        {
            cliente.direccion.localidad = elecLocalidad.Text;
        }

        private void elecCP_TextChanged(object sender, EventArgs e)
        {
            cliente.direccion.codPostal = elecCP.Text;
        }

        private void nuevoRol_Click(object sender, EventArgs e)
        {
            AsistenteVistas.mostrarNuevaVentana(new AgregarRol(cliente.user,this),this);
        }
    }
}
