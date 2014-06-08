using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Asistentes
{
    class AsistenteCliente : AdaptadorBD
    {
        public static void altaCliente( string username,
                                        string pass,
                                        int passDefinitiva,
                                        string rol,
                                        string nombre,
                                        string apellido,
                                        string tipoDoc,
                                        string numeroDoc,
                                        string email,
                                        string telefono,
                                        string calle,
                                        string numero,
                                        string piso,
                                        string departamento,
                                        string localidad,
                                        string codPostal,
                                        DateTime fechaNac)
        {
            AsistenteUsuario.altaUsuario(username,pass,passDefinitiva,rol);
            AsistenteUsuario.altaDireccion(calle,
                                            numero,
                                            piso,
                                            departamento,
                                            codPostal,
                                            localidad);
            AdaptadorBD.ejecutarProcedure("alta_cliente",
                username,
                Convert.ToInt64(numeroDoc),
                tipoDoc,
                nombre,
                apellido,
                email,
                Convert.ToInt64(telefono),
                AsistenteUsuario.getIdDireccion(calle,numero,piso,departamento,codPostal,localidad),
                fechaNac
                );

        }

        public static bool existeTelefonoCliente(string telefono)
        {
            return ejecutarProcedureWithReturnValue("existe_telefono_cliente",Convert.ToInt64(telefono))==1;
        }

        public static void chequearTipoYNroDocNoRepetido(string tipo, string numero, List<string> errores) 
        {
            if (existeTipoYNumeroDoc(tipo, Convert.ToInt64(numero)))
            {
                errores.Add("Ya existe un cliente con tal tipo y número de documento.\n Se le recuerda que cada cliente puede estar registrado una única vez.");
            }
        }

        public static bool existeTipoYNumeroDoc(string tipo, Int64 numero)
        {
            return ejecutarProcedureWithReturnValue("existe_tipo_y_numero_doc",tipo,numero) == 1;
        }
    }
}
