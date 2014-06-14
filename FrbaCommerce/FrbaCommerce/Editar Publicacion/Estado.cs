using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generar_Publicacion
{
    public abstract class Estado
    {
        public static Dictionary<string, Estado> estados = new Dictionary<string, Estado>() 
        { 
            { "Borrador", new Borrador() },
            { "Publicada", new Publicada() },
            {"Pausa", new Pausa()},
            {"Finalizada", new Finalizada()}
        };

        public static Estado getEstado(string nombre)
        {
            return estados[nombre];
        }

        public abstract void abrirEditorParaSubasta(Publicacion publi);
        public abstract void abrirEditorParaVentaDirecta(Publicacion publi);
        public abstract string nombre();
    }
}
