using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public abstract class FormaDePago
    {
        public abstract void perdurar(int factura, int numeroDeRenglon);

        public static FormaDePago newFormaDePago(SiguienteARendir form)
        {
            string forma = form.getForma();
            if(forma.Equals("Tarjeta"))
                return new Tarjeta(form);
            if(forma.Equals("Efectivo"))
                return new Efectivo();
            else
                throw new HayCamposEnBlanco("No se ingreso forma de pago");
        }

        public abstract string getNombre();
    }
}
