using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Excepciones;

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
    }
}
