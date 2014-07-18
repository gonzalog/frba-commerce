using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using System.Data;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Comprar_Ofertar;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public class Subasta : Tipo
    {
        private Subasta() { }
        public static Subasta newSaver()
        { 
            return new Subasta();
        }

        public override string procedure()
        {
            return "alta_subasta";
        }

        public Subasta(int idPubli)
        {
            DataRow fila;
            try
            {
                fila = AdaptadorBD.traerDataTable("subasta_por_pub", idPubli).Rows[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new SubastaInexistente();
            }
            this.id = Convert.ToInt32(fila["id"].ToString());
            this.stock = Convert.ToInt32(fila["cantidad"].ToString());

            string textoPrecio = fila["precio_inicial"].ToString();
            if (!textoPrecio.Equals(""))
                this.precioInicial = Convert.ToDecimal(textoPrecio);
            else
                this.precioInicial = 0;
        }

        public override void abrirEditorEnEstado(Estado estado,Publicacion publi)
        {
            estado.abrirEditorParaSubasta(publi);
        }

        public override string nombreTipo()
        {
            return "Subasta";
        }
        public override int getCodPublicacion(int codigoPropio)
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("get_publicacion_de_subasta", codigoPropio);
        }

        public override void perdurar()
        {
            AdaptadorBD.ejecutarProcedure("editar_subasta",id,precioInicial,stock);
        }

        public override decimal precioActual()
        {
            return AdaptadorBD.ejecutarProcedureWithReturnDecimal("precio_actual_subasta",this.id);
        }

        public override void abrirVentanaInteresado(Form padre, Publicacion publicacion, string user) 
        {
            AsistenteVistas.mostrarNuevaVentana(new InteresadoSubasta(publicacion,user,padre),padre);
        }

        public override int cantidadFacturada(string usuario)
        {
            return AsistentePublicacion.cantidadSubastasFacturadas(usuario);
        }
    }
}
