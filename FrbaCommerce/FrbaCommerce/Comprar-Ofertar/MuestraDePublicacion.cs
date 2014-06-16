using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Asistentes;
using System.Windows.Forms;

namespace FrbaCommerce.Comprar_Ofertar
{
    class MuestraDePublicacion
    {
        public Publicacion publicacion;

        public MuestraDePublicacion(int cod,Label descrpcion,Label precio, Button boton)
        {
            publicacion = new Publicacion(cod);
            descrpcion.Text = publicacion.descripcion;
            precio.Text = publicacion.tipo.precioActual().ToString();
            mostrar(descrpcion,precio,boton);
        }

        private void mostrar(Label descrpcion, Label precio, Button boton)
        {
            descrpcion.Show();
            precio.Show();
            boton.Show();
        }

        public void hayUnInteresado(string user)
        {
            this.publicacion.hayUnInteresado(user);
        }
    }
}
