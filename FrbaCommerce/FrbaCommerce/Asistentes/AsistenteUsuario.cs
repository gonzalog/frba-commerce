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
                errores.Add("El nombre de usuario" + username + "ya existe.");
                return false;
            }
            return true;
        }

        public static void contraseñaValida(string pass,List<string> errores)
        {
            if (String.IsNullOrEmpty(pass)) errores.Add("El campo contraseña está vacío.");
        }
    }
}
