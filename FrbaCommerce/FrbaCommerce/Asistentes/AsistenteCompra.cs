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

        public static void altaCalificacion(int estrellas, string opinion, int adquisicion,string tipo)
        {
            ejecutarProcedure("alta_calificacion",estrellas,opinion);
            int idCalif = ejecutarProcedureWithReturnValue("ultima_calificacion");
            if (tipo.Equals("Venta directa"))
            {
                ejecutarProcedure("compra_asignar_calificacion",adquisicion,idCalif);
            }
            else if (tipo.Equals("Subasta"))
            {
                ejecutarProcedure("oferta_asignar_calificacion", adquisicion, idCalif);
            }
            else
            {
                throw new TipoIncorrecto("El tipo no es ni subasta ni venta directa.");
            }
        }

        public static Publicacion siguienteAFacturar(string usuario, int numeroDeRendido)
        {
            try
            {
                DataRow fila = traerDataTable("siguiente_publi_a_facturar", usuario).Rows[numeroDeRendido];
                System.Diagnostics.Debug.WriteLine("Se instancia publicación de id: " + fila["id"].ToString());
                return new Publicacion(Convert.ToInt32(fila["id"].ToString()));
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
