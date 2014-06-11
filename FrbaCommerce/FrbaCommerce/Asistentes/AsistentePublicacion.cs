using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Asistentes
{
    class AsistentePublicacion : AdaptadorBD
    {
        public static Dictionary<string, int> getRubros()
        {
            Dictionary<string, int> rubros = new Dictionary<string, int>();
            DataTable tabla = traerDataTable("get_rubros");
            foreach (DataRow fila in tabla.Rows)
            {
                string descrip = fila["descripcion"].ToString();
                int cod = Convert.ToInt32(fila["codigo"].ToString());
                rubros.Add(descrip, cod);
            }
            return rubros;
        }
    }
}
