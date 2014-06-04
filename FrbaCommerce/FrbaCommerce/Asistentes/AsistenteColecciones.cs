using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Asistentes;

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

        public static Dictionary<string, int> crearDic(DataTable tabla) 
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach(DataRow row in tabla.Rows)
            {
                dic.Add(row[0].ToString(), Convert.ToInt32(row[1].ToString()));
            }
            return dic;
        }

    }
}
