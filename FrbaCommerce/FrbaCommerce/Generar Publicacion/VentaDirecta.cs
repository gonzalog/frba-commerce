using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using System.Data;
using FrbaCommerce.Abm_Visibilidad;

namespace FrbaCommerce.Generar_Publicacion
{
    class VentaDirecta : Tipo
    {
        public override string procedure()
        {
            return "alta_venta_directa";
        }
    }
}
