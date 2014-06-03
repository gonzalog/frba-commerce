using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Asistentes
{
    class AsistenteColecciones
    {
        public static bool cambiarStringDeLista(string cadena, List<string> listaVieja, List<string> listaNueva)
        {
            if (listaVieja.Remove(cadena))
            {
                listaNueva.Add(cadena);
                return true;
            }
            return false;
        }

        public static bool cambiarStringIntDeDict(string cadena, Dictionary<string, int> dicViejo, Dictionary<string, int> dicNuevo)
        {
            if (dicViejo.Any(par=>par.Key.Equals(cadena)))
            {
                dicNuevo.Add(cadena,dicViejo[cadena]);
                dicViejo.Remove(cadena);
                return true;
            }
            return false;
        }

    }
}
