using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Asistentes
{
    class AsistenteCompra : AdaptadorBD
    {
        public static DataRow getDataCompra(int cod)
        {
            return traerDataTable("get_data_compra",cod).Rows[0];
        }

        public static void altaCalificacion(int estrellas, string opinion, int compra)
        {
            ejecutarProcedure("alta_calificacion", compra, estrellas, opinion);
        }

        public static Publicacion siguienteAFacturar(string usuario, int numeroDeRendido)
        {
            try
            {
                DataRow fila = traerDataTable("siguiente_publi_a_facturar", usuario).Rows[numeroDeRendido];
                System.Diagnostics.Debug.WriteLine("Se instancia publicación de id: " + fila["id"].ToString());

                Publicacion publi = new Publicacion(Convert.ToInt32(fila["id"].ToString()));
                return publi;
            }
            catch (NullReferenceException)
            {
                throw new NoHayMasParaFacturar();
            }
            catch (IndexOutOfRangeException)
            {
                throw new NoHayMasParaFacturar();
            }
        }
    }
}
