using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generar_Publicacion
{
    public abstract class Tipo
    {
        private static Dictionary<string, Tipo> tipos = new Dictionary<string, Tipo>() 
        { 
            { "Subasta", new Subasta() },
            { "Compra inmediata", new VentaDirecta() }         
        };
        public static Tipo getTipo(string nombre)
        { 
            return tipos[nombre];
        }

        abstract public void darDeALta(string descrip,string stock,string precio,string visi,string user,string estado,List<string> rubros,bool hayPreguntas);
    }
}
