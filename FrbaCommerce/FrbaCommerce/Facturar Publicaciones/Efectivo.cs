using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public class Efectivo : FormaDePago
    {
        public override void perdurar(int factura, int numeroDeRenglon) 
        {}

        public override string getNombre() 
        {
            return "Efectivo";
        }
    }
}
