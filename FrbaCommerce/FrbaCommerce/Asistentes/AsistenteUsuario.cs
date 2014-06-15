using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using System.Data;
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Asistentes
{
    class AsistenteUsuario : AdaptadorBD
    {
        public static bool existeUsername(string username)
        { 
            return (ejecutarProcedureWithReturnValue("existe_username",username).Equals(1));
        }

        public static bool userNameValido(string username, List<String> errores)
        {
            if (String.IsNullOrEmpty(username))
            {
                errores.Add("El nombre de usuario no puede estar vacío.");
                return false;
            }

            if (existeUsername(username))
            {
                errores.Add("El nombre de usuario '" + username + "' ya existe.");
                return false;
            }
            return true;
        }

        public static void contraseñaValida(string pass,string confirPass, List<string> errores)
        {
            if (String.IsNullOrEmpty(pass)) errores.Add("El campo contraseña está vacío.");
            if (pass != confirPass) errores.Add("La contraseña no coincide con su confirmación.");
        }

        public static void altaUsuario(string username, string pass,int passDefinitiva, string nombreRol)
        {
            AdaptadorBD.ejecutarProcedure("alta_usuario",   
                                          username,
                                          AsistenteLogin.getSha256(pass),
                                          passDefinitiva
                                          );
            altaRolPorUser(username, AsistenteRol.getCodRol(nombreRol));
        }

        public static void altaRolPorUser(string name, int codRol) 
        {
            AdaptadorBD.ejecutarProcedure("alta_rol_por_user",codRol,name);
        }

        public static void altaDireccion(   string calle,
                                            string numero,
                                            string piso,
                                            string departamento,
                                            string codigoPostal,
                                            string localidad
                                            ) 
        {
            AdaptadorBD.ejecutarProcedure(  "alta_direccion",
                                            calle,
                                            Convert.ToInt32(numero),
                                            Convert.ToInt32(piso),
                                            departamento,
                                            codigoPostal,
                                            localidad
                                            );
        }

        public static int getIdDireccion(string calle,
                                        string numero,
                                        string piso,
                                        string departamento,
                                        string codigoPostal,
                                        string localidad
                                        )
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("get_id_direccion",
                                                                calle,
                                                                codigoPostal,
                                                                departamento,
                                                                numero,
                                                                piso,
                                                                localidad
                                                                );
        }

        public static bool esPasswordCorrecta(string user, string pass)
        {
            return getHashPassword(user) == AsistenteLogin.getSha256(pass);
        }

        public static string getHashPassword(string user)
        {
            return ejecutarProcedureWithReturnString("get_hash_password",user);
        }

        public static void cambiarPassword(string user,string pass)
        {
            ejecutarProcedure("cambiar_password",user,AsistenteLogin.getSha256(pass));
        }

        public static void inhabilitarUsuario(string user)
        {
            ejecutarProcedure("inhabilitar_user",user);
        }

        public static void habilitarUsuario(string user)
        {
            ejecutarProcedure("habilitar_user", user);
        }

        public static DataRow getDataDireccion(string id)
        {
            return traerDataTable("get_data_direccion",id).Rows[0];
        }

        public static void editarDireccion(Direccion dir)
        {
            ejecutarProcedure("editar_direccion",dir.id,dir.calle,dir.numero,dir.piso,dir.depto,dir.codPostal,dir.localidad);
        }

        public static DataTable getPregsParaBuscando(string descripcion, string user)
        {
            return traerDataTable("get_pregs_para_buscando",descripcion,user);
        }

        public static DataTable getPregsRespondidasBuscando(string busqueda, string user)
        {
            return traerDataTable("get_pregs_respondidas_para_buscando", busqueda, user);
        }
    }
}
