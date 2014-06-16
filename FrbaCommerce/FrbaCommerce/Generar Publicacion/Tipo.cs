using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using System.Data;
using FrbaCommerce.Abm_Visibilidad;

namespace FrbaCommerce.Generar_Publicacion
{
    public abstract class Tipo
    {
        public int id;
        public int stock;
        public decimal precioInicial;

        public abstract string procedure();
        private static Dictionary<string, Tipo> tipos = new Dictionary<string, Tipo>() 
        { 
            { "Subasta", Subasta.newSaver() },
            { "Compra inmediata", VentaDirecta.newSaver() }         
        };
        public static Tipo getTipoSaver(string nombre)
        { 
            return tipos[nombre];
        }

        public void darDeALta(string descrip, string stock, string precio, string visi, string user, string estado, List<string> rubros, bool hayPreguntas)
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
                //Significa que esta visibilidad ya fue usada por el usuario.
            }

            decimal prec;
            try
            {
                prec = Convert.ToDecimal(precio);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Precio inválido.");
                return;
            }
            AdaptadorBD.ejecutarProcedure(this.procedure(), prec, estado, visiCod, user, descrip, DateTime.Now.Date, DateTime.Now.AddDays(duracion).Date, Convert.ToInt32(stock), hayPreguntas ? 1 : 0);
            int codDePub = AsistentePublicacion.getCodUltimaPublicacion();
            foreach(string rubro in rubros)
                AsistentePublicacion.altaRubroPorPublicacion(rubro, codDePub);
        }

        public abstract void abrirEditorEnEstado(Estado estado,Publicacion publi);
        public abstract string nombreTipo();
        public abstract int getCodPublicacion(int codigoPropio);

        public abstract void perdurar();

        public abstract decimal precioActual();

        public abstract void abrirVentanaInteresado(Publicacion publicacion, string user);
    }
}
