using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Abm_Visibilidad;
using System.Data;

namespace FrbaCommerce.Asistentes
{
    class AsistenteVisibilidad : AdaptadorBD
    {
        public static void chequearCodigoUnico(int cod)
        {
            if (ejecutarProcedureWithReturnValue("existe_cod_visibilidad", cod) == 1) 
                throw new CodigoRepetido("Ese código de visibilidad ya se encuentra registrado.");
        }

        public static void altaVisibilidad(int cod,string descrip, double precio, double porcentaje)
        {
            try
            {
                ejecutarProcedure("alta_visibilidad", cod, descrip, precio, porcentaje);
            }
            catch (Exception)
            {
                throw new FallaDelMotor("Error en el alta del usuario.");
            }
        }

        public static void editarVisibilidad(Visibilidad visibilidad)
        {
            Int64 codigo = Convert.ToInt64(visibilidad.cod);
            double precio;
            try
            {
                precio = Convert.ToDouble(visibilidad.precio);
            }
            catch (FormatException)
            {
                precio = 0;
            }
            double porcentaje;
            try
            {
                porcentaje = Convert.ToDouble(visibilidad.porcentaje);
            }
            catch (FormatException)
            {
                porcentaje = 0;
            }
            try
            {
                ejecutarProcedure("editar_visibilidad",codigo,visibilidad.descripcion,precio,porcentaje);
            }
            catch (Exception)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema();
            }
        }

        public static DataTable getTableBuscando(string descrip)
        {
            return traerDataTable("get_visibilidades_buscando",descrip);
        }
        public static Visibilidad newVisibilidad(int cod)
        {
            DataRow susDatos = getDataVisi(cod);
            return new Visibilidad(susDatos);
        }

        private static DataRow getDataVisi(int cod)
        {
            return traerDataTable("get_data_visibilidad", cod).Rows[0];
        }

        public static void inhabilitarVisibilidad(string cod)
        {
            try
            {
                long visiCod = Convert.ToInt64(cod);
                ejecutarProcedure("inhabilitar_visibilidad", visiCod);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("La baja no pudo realizarse.");
            }
        }
    }
}
