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
    public partial class InteresadoSubasta : Form
    {
        public string usuario;
        public Publicacion publicacion;
        public Vendedor vendedor;
        public InteresadoSubasta(Publicacion publicacion, string user)
        {
            InitializeComponent();
            this.publicacion = publicacion;
            this.usuario = user;
            vendedor = AsistenteUsuario.getVendedor(publicacion.usuarioCreador);

            if (!publicacion.hayPreguntas)
                boxConsulta.Enabled = false;

            descrip.Text = publicacion.descripcion;
            stock.Text = publicacion.tipo.stock.ToString();
            publicDate.Text = publicacion.fechaInicio.ToString();
            vencimiento.Text = publicacion.vencimiento.ToString();
            precioInicial.Text = publicacion.tipo.precioInicial.ToString();
            precioActual.Text = publicacion.tipo.precioActual().ToString();
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
            AdaptadorBD.ejecutarProcedure("alta_pregunta", usuario, publicacion.id, consultaText.Text);
            consultaText.Text = "";
        }

        private void BotonOfertar_Click(object sender, EventArgs e)
        {
            if (usuario.Equals("admin"))
            {
                MessageBox.Show("Concretar una oferta es una funcionalidad exclusiva de usuarios de tipo cliente.");
                return;
            }
            int monto;
            try
            {
                monto = Convert.ToInt32(montoOferta.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingrese un valor entero en el campo 'Monto'.");
                return;
            }
            if(monto>publicacion.tipo.precioActual())
            {
                try
                {
                    AdaptadorBD.ejecutarProcedure("alta_cliente_por_publicacion", usuario, publicacion.id);
                }
                catch (Exception)
                {
                    //Los datos ya estaban cargados previamente.
                }
                AdaptadorBD.ejecutarProcedure("alta_oferta",usuario,publicacion.id,monto);
                MessageBox.Show("Oferta exitosa.");
                precioActual.Text = publicacion.tipo.precioActual().ToString();
                montoOferta.Text = "";
            }
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
