using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Asistentes
{
    class AsistenteRol : AdaptadorBD
    {

        public static void inhabilitarRol(int codRol) //para dar de baja
        {
            ejecutarProcedure("inhabilitar_rol", codRol);
        }

        public static void habilitarRol(int codRol) //para dar de baja
        {
            ejecutarProcedure("habilitar_rol", codRol);
        }

        public static void updateNombre(int cod, string nombre)
        {
            ejecutarProcedure("modificar_rol_nombre", cod, nombre);
        }

        public static void updateBajaFuncionPorRol(int cod,int funcion)
        {
            ejecutarProcedure("baja_funcion_por_rol", cod, funcion);
        }

        public static void updateAltaFuncionPorRol(int cod, int funcion)
        {
            ejecutarProcedure("alta_funcion_por_rol", cod, funcion);
        }

        public static int altaRol(string nombre,int habilitado,int[] funciones)
        {
            ejecutarProcedure("alta_rol",nombre, habilitado);
            int codNuevo = ejecutarProcedureWithReturnValue("get_cod_rol",nombre);

            foreach(int funcion in funciones)
            {
                updateAltaFuncionPorRol(codNuevo,funcion);
            }

            return codNuevo;
        }


        public static DataTable getFunciones()
        {
            return traerDataTable("get_funciones");
        }

        public static DataTable getRoles()
        {
            return traerDataTable("get_roles");
        }

    }
}