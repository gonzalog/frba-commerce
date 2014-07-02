using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class InteresadoVentaDirecta : Form
    {
        public string usuario;
        public Publicacion publicacion;
        public Vendedor vendedor;
        public InteresadoVentaDirecta(Publicacion publicacion,string user)
        {
            InitializeComponent();
            descrip.Text = publicacion.descripcion;
            stock.Text = publicacion.tipo.stock.ToString();
            precio.Text = publicacion.tipo.precioInicial.ToString();
            publicDate.Text = publicacion.fechaInicio.ToString();
            vencimiento.Text = publicacion.vencimiento.ToString();
            this.publicacion = publicacion;
            this.usuario = user;

            vendedor = AsistenteUsuario.getVendedor(publicacion.usuarioCreador);

            if (!publicacion.hayPreguntas)
                boxConsulta.Enabled = false;
            cantidadCompra.Maximum = publicacion.tipo.stock;
            AsistenteBotones.hacerNoEditable(cantidadCompra);
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma que no quiere comprar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BotonComprar_Click(object sender, EventArgs e)
        {
            if (usuario.Equals("admin"))
            {
                MessageBox.Show("Concretar una compra es una funcionalidad exclusiva de usuarios de tipo cliente.");
                return;
            }

            AdaptadorBD.ejecutarProcedure("alta_compra", usuario, publicacion.id, cantidadCompra.Value);
            vendedor.mostrarDatos();
            Close();
        }

        private void BotonConsultar_Click(object sender, EventArgs e)
        {
            if (usuario.Equals("admin"))
            {
                MessageBox.Show("La consulta es una funcionalidad exclusiva de usuarios de tipo cliente.");
                return;
            }
            try
            {
                AdaptadorBD.ejecutarProcedure("alta_cliente_por_publicacion", usuario, publicacion.id);
            }
            catch (Exception)
            { 
                //Los datos ya estaban cargados previamente.
            }
            AdaptadorBD.ejecutarProcedure("alta_pregunta",usuario,publicacion.id,consultaText.Text);
            consultaText.Text = "";
        }
    }
}
