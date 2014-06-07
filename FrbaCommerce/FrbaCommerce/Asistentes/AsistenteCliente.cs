using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Asistentes
{
    class AsistenteCliente
    {
        public static void altaCliente( string username,
                                        string pass,
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
            AsistenteUsuario.altaUsuario(username,pass,rol);
            AsistenteUsuario.altaDireccion(calle,
                                            numero,
                                            piso,
                                            departamento,
                                            codPostal,
                                            localidad);
            AdaptadorBD.ejecutarProcedure("alta_cliente",
                username,
                Convert.ToInt32(numeroDoc),
                tipoDoc,
                nombre,
                apellido,
                email,
                Convert.ToInt64(telefono),
                AsistenteUsuario.getIdDireccion(calle,numero,piso,departamento,codPostal,localidad),
                fechaNac
                );

        }
    }
}
