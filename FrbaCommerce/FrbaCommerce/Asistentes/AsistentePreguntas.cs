using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.Asistentes
{
    class AsistentePreguntas : AdaptadorBD
    {
        public static void perdurarRespuesta(int pregunta, string respuesta)
        {
            try
            {
                ejecutarProcedure("alta_respuesta",pregunta,respuesta);
            }
            catch (Exception)
            {
                throw new FallaDelMotor("Error al intentar perdurar respuesta.");
            }
        }

        public static string getDescripcionRespuesta(int codigo)
        {
            return ejecutarProcedureWithReturnString("get_descripcion_respuesta",codigo);
        }
    }
}
