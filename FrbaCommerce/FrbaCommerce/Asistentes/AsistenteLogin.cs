using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FrbaCommerce.Asistentes
{
    class AsistenteLogin
    {
        //Chequea contraseña, resetea o incrementa el contador de intentos y retorna el valor de este.
        public static int intentarLoguear(string username, string password)
        {
            string passEncriptada = getSha256(password);

            if (AdaptadorBD.ejecutarProcedureWithReturnValue("corroborar_pass", username, passEncriptada) == 1)
            {
                AdaptadorBD.ejecutarProcedure("reset_intentos",username);
            }
            else
            {
                AdaptadorBD.ejecutarProcedure("increm_intent_fallidos_usuario", username);      
            }
            return AdaptadorBD.ejecutarProcedureWithReturnValue("intentos_de", username);
        }

        public static void inhabilitarUsuario(string username) 
        {
            AdaptadorBD.ejecutarProcedure("inhabilitar_user",username);
        }

        public static void habilitarUsuario(string username)
        {
            AdaptadorBD.ejecutarProcedure("habilitar_user", username);
        }

        public static bool getHabilitadoUsuario(string username)
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("habilitado_user", username)==1;
        }

        public static String getSha256(String input)
        {
            SHA256Managed encriptador = new SHA256Managed();
            byte[] inputEnBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashBytes = encriptador.ComputeHash(inputEnBytes);
            return BitConverter.ToString(inputHashBytes).Replace("-", String.Empty).ToLower();
        }
        public static bool passwordPermanente(string user)
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("password_permanente",user) == 1;
        }
    }
}
