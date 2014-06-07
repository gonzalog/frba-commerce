using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Asistentes
{
    class AsistenteEmpresa
    {
        public static void altaEmpresa(  string username,
                                        string password,
                                        string rol,
                                        string razonSocial,
                                        string mail,
                                        string telefono,
                                        string calle,
                                        string numero,
                                        string piso,
                                        string departamento,
                                        string localidad,
                                        string codPost,
                                        string ciudad,
                                        string CUIT,
                                        string nombreContacto,
                                        DateTime fechaCreacion 
                                        ) 
        {
            AsistenteUsuario.altaUsuario(username, password, rol);
            AsistenteUsuario.altaDireccion(calle,
                                            numero,
                                            piso,
                                            departamento,
                                            codPost,
                                            localidad);
            AdaptadorBD.ejecutarProcedure("alta_empresa",
                username,
                Convert.ToInt32(CUIT),
                razonSocial,
                mail,
                Convert.ToInt32(telefono),
                AsistenteUsuario.getIdDireccion(calle, numero, piso, departamento, codPost, localidad),
                ciudad,
                nombreContacto,
                fechaCreacion
                );
        }
    }
}
