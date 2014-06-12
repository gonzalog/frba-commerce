using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generar_Publicacion
{
    public abstract class Estado
    {
        private static Dictionary<string, Estado> estados = new Dictionary<string, Estado>() 
        { 
            { "Borrador", new Borrador() },
            { "Publicada", new Publicada() },
            {"Pausa", new Pausa()},
            {"Finalizada", new Finalizada()}
        };

        public Estado getEstado(string nombre)
        {
            return estados[nombre];
        }
    }
}
