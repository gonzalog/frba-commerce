﻿using System;
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

        public static DataTable getPublicsBuscando(string descrip)
        {
            return traerDataTable("get_publicaciones_buscando",descrip);
        }
        public static DataTable getPublicsBuscando(string descrip,string user)
        {
            return traerDataTable("get_publics_de_user_buscando", descrip,user);
        }
    }
}
