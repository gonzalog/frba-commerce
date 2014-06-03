using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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

        public static int altaRol(string nombre,int habilitado,List<int> funciones)
        {
            ejecutarProcedure("alta_rol",nombre, habilitado);
            int codNuevo = ejecutarProcedureWithReturnValue("get_cod_rol",nombre);
            funciones.ForEach((int f)=>updateAltaFuncionPorRol(codNuevo,f));
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

        public static DataTable getRolesBuscando(string nombreABuscar)
        {
            return traerDataTable("get_roles_buscando", nombreABuscar);
        }

        public static Dictionary<int, string> getRolesExistentes()
        {
            DataTable tablaRoles = getRoles();
            DataRowCollection rows = tablaRoles.Rows;
            //MessageBox.Show("Hay " + rows.Count + " roles cargados");
            Dictionary<int, string> roles = new Dictionary<int, string>();
            foreach (DataRow row in rows)
            {
                int cod = Convert.ToInt32(row["cod_rol"].ToString());
                string descripcion = row["nombre"].ToString();
                roles.Add(cod, descripcion);
            }
            return roles;
        }

        public static DataTable traerDataTableRoles(string nombre)
        {
            return traerDataTable("get_roles", nombre);
        }

        public static bool rolHabilitado(int rol) 
        {
            return (ejecutarProcedureWithReturnValue("rol_habilitacion",rol)==1);
        }

        public static Dictionary<int,string> getNombresFunciones() 
        {
            DataTable funcionesTraidas = traerDataTable("get_funciones");

            DataRowCollection rows = funcionesTraidas.Rows;
            
            Dictionary<int, string> funciones = new Dictionary<int, string>();
            foreach (DataRow row in rows)
            {
                int cod = Convert.ToInt32(row["cod_funcion"].ToString());
                string descripcion = row["nombre"].ToString();
                
                funciones.Add(cod,descripcion);
            }
            return funciones;
        }

        public static string getNombreRol(int cod)
        {
            string nombre = ejecutarProcedureWithReturnString("get_nombre_rol",cod);
            MessageBox.Show("El nombre es: "+nombre);
            return nombre;
        }

        public static List<int> getFuncionesDe(int rol)
        {
            return _getFuncionesSegun("get_funciones_de", rol);
        }

        public static List<int> getFuncionesNoDe(int rol)
        {
            return _getFuncionesSegun("get_funciones_no_de", rol);
        }

        private static List<int> _getFuncionesSegun( string proc,int rol)
        {
            List<int> funcionesARetornar = new List<int>();

            DataTable funciones = traerDataTable(proc, rol);
            DataRowCollection filas = funciones.Rows;
            foreach (DataRow row in filas)
            {
                funcionesARetornar.Add(Convert.ToInt32(row["cod_funcion"].ToString()));
            }
            return funcionesARetornar;
        }

        public static string getNombreFuncion(int cod)
        {
            return ejecutarProcedureWithReturnString("get_nombre_funcion",cod);
        }
    }
}