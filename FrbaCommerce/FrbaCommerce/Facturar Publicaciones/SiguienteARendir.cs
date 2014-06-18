using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class SiguienteARendir : Form
    {
        public Publicacion publiAFacturar;
        public Factura factura;
        public int numeroDeRendido;
        public SiguienteARendir(Factura factura,int numeroDeRendido)
        {
            InitializeComponent();
            this.factura = factura;
            this.numeroDeRendido = numeroDeRendido;
            string user = factura.user;
            this.publiAFacturar = AsistenteCompra.siguienteAFacturar(user, numeroDeRendido);
            System.Diagnostics.Debug.WriteLine(publiAFacturar.id);

            inicializarFormulario();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void inicializarFormulario()
        {
            System.Diagnostics.Debug.WriteLine(publiAFacturar.id);
            titulo.Text = publiAFacturar.descripcion;
            comiVisi.Text = publiAFacturar.visibilidad.precio;
            comiUnis.Text = publiAFacturar.comisionPorUnidadesVendidas().ToString();
            formaPago.Items.Add("Efectivo");
            formaPago.Items.Add("Tarjeta");
            AsistenteBotones.hacerNoEditable(formaPago);
            datosTarjeta.Enabled = false;
        }

        private void formaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formaPago.Text.Equals("Tarjeta"))
                datosTarjeta.Enabled = true;
            else
                datosTarjeta.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AsistenteBotones.checkSoloNumericos(numero);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Recuerde que todas las publicaciones facturadas son instántaneamente finalizadas. ¿Está seguro/a?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                factura.perdurar();
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                factura.addRenglon(new Renglon(this));
            }
            catch (HayCamposEnBlanco)
            {
                MessageBox.Show("La forma de pago no puede quedar en blanco.");
                return;
            }
            try
            {
                AsistenteVistas.mostrarSimultaneo(new SiguienteARendir(factura, numeroDeRendido+1));
                Close();
            }
            catch 
            (NoHayMasParaFacturar)
            {
                MessageBox.Show("No hay más facturas pendientes.");
            }
        }

        public string getNumero()
        {
            return numero.Text;
        }

        public string getNombre()
        {
            return nombre.Text;
        }

        public string getApellido()
        {
            return apellido.Text;
        }

        public string getForma()
        {
            return formaPago.Text;
        }

        public decimal getComiVisi()
        {
            return Convert.ToDecimal(comiVisi.Text);
        }

        public decimal getComiUnis()
        {
            return Convert.ToDecimal(comiUnis.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Recuerde que todas las publicaciones facturadas son instántaneamente finalizadas. ¿Está seguro/a?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    factura.addRenglon(new Renglon(this));
                }
                catch (HayCamposEnBlanco)
                {
                    MessageBox.Show("La forma de pago no puede quedar en blanco.");
                    return;
                }

                factura.perdurar();
                Close();
            }
        }
    }
}
