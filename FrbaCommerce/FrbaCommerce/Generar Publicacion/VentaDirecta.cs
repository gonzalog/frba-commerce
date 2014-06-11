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
        public override void darDeALta(string descrip, string stock, string precio, string visi, string user, string estado, List<string> rubros, bool hayPreguntas)
        {
            int visiCod = AsistenteVisibilidad.getVisibilidades()[visi];
            DataRow visiData = AsistenteVisibilidad.getDataVisi(visiCod);
            Visibilidad visibilidad = new Visibilidad(visiData);
            int duracion = visibilidad.duracion();
            try
            {
                AdaptadorBD.ejecutarProcedure("alta_visibilidad_por_user", visiCod, user);
            }
            catch (Exception)
            { 
            }
            AdaptadorBD.ejecutarProcedure("alta_venta_directa", estado, visiCod, user, descrip, DateTime.Now, DateTime.Now.AddDays(duracion), hayPreguntas ? 1 : 0);
        }
    }
}
