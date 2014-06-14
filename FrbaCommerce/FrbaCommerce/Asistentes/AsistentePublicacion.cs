using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Excepciones;

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

        public static DataRow getFila(int id)
        {
            return traerDataTable("get_fila_publicacion",id).Rows[0];
        }
        public static Tipo getTipo(int idPubli)
        {
            Tipo tipo;
            try
            {
                tipo = new Subasta(idPubli);
            }
            catch (SubastaInexistente)
            {
                tipo = new VentaDirecta(idPubli);
            }
            catch (Exception)
            {
                throw new TipoIncorrecto("Se pide un tipo incorrecto");
            }
            
            return tipo;
        }

        public static Dictionary<string, int> getRubrosDe(Publicacion publicacion)
        {
            Dictionary<string, int> rubros = new Dictionary<string, int>();
            DataTable tabla = traerDataTable("get_rubros_de",publicacion.id);
            foreach (DataRow fila in tabla.Rows)
            {
                int cod = Convert.ToInt32(fila["codigo"].ToString());
                string descrip = fila["descripcion"].ToString();
                rubros.Add(descrip,cod);
            }
            return rubros; 
        }

        public static Dictionary<string, int> getRubrosNoDe(Publicacion publicacion)
        {
            Dictionary<string, int> totalRubros = getRubros();
            Dictionary<string, int> rubrosDe = getRubrosDe(publicacion);
            return totalRubros.Where(rubro => !rubrosDe.Values.Contains(rubro.Value)).ToDictionary(rubro => rubro.Key, rubro => rubro.Value) ;
        }

        public static void altaRubroPorPublicacion(string rubro, int codigoPublicacion)
        {
            ejecutarProcedure("alta_rubro_por_publicacion", rubro, codigoPublicacion);
        }

        public static int getCodUltimaPublicacion()
        {
            return ejecutarProcedureWithReturnValue("ultima_publicacion");
        }

        public static void editarPublicacion(Publicacion publicacion)
        {
            System.Diagnostics.Debug.WriteLine("Se guarda con el campo hay_preguntas: " + (publicacion.hayPreguntas ? 1 : 0));
            ejecutarProcedure("editar_publicacion",publicacion.id,publicacion.visibilidad.cod,publicacion.estado.nombre(),publicacion.hayPreguntas?1:0);
        }
    }
}
