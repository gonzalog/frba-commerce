using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Asistentes
{
    class AsistenteEmpresa
    {
        public static void altaEmpresa(  string username,
                                        string password,
                                        int passDefinitiva,
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
            AsistenteUsuario.altaUsuario(username, password,passDefinitiva, rol);
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

        public static void chequearTextboxNoNuloYRSUnica(TextBox elec,List<string> errores,string campo)
        {
            AsistenteBotones.chequearTextboxNoNulo(elec,errores,campo);
            chequearNoExisteRS(elec.Text,errores);
        }

        public static void chequearNoExisteRS(string RS,List<string> errores) 
        {
            if (existeRazonSocial(RS)) errores.Add("La razón social ya está registrada.");
        }

        public static bool existeRazonSocial(string RS)
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("existe_razon_social",RS)==1;
        }

        public static void chequearTextboxNoNuloYCUIT(TextBox elec, List<string> errores, string campo)
        {
            AsistenteBotones.chequearTextboxNoNulo(elec, errores, campo);
            chequearNoExisteCUIT(elec.Text, errores);
        }

        public static void chequearNoExisteCUIT(string CUIT, List<string> errores)
        { 
            if(existeCUIT(CUIT)) errores.Add("El CUIT ya está registrado.");
        }

        public static bool existeCUIT(string cuit)
        {
            return AdaptadorBD.ejecutarProcedureWithReturnValue("existe_cuit",cuit)==1;
        }
    }
}
