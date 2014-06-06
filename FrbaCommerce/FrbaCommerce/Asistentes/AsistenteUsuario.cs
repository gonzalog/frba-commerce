using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;

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

        public static void contraseñaValida(string pass,List<string> errores)
        {
            if (String.IsNullOrEmpty(pass)) errores.Add("El campo contraseña está vacío.");
        }

        public static void altaUsuario(string username, string pass, string nombreRol)
        {
            AdaptadorBD.ejecutarProcedure("alta_usuario",   
                                          username, 
                                          AsistenteLogin.getSha256(pass)
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
    }
}
