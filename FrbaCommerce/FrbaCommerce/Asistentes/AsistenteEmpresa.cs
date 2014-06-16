using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Excepciones;
using System.Data;
using FrbaCommerce.Abm_Empresa;

namespace FrbaCommerce.Asistentes
{
    class AsistenteEmpresa : AdaptadorBD
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
            try
            {
                AsistenteUsuario.altaUsuario(username, password, passDefinitiva, rol);
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
            catch (OverflowException)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema("Error por existencia de datos excesivamente largos.");
            }
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

        public static DataTable getTableBuscando(string razon,string cuit,string email)
        {
            return AdaptadorBD.traerDataTable("get_empresas_buscando",razon,cuit,email);
        }

        public static bool existeTelefonoEmpresaExceptuandoA(string telefono, string user)
        {
            try
            {
                return ejecutarProcedureWithReturnValue("existe_telefono_empresa_exceptuando_a", Convert.ToInt64(telefono), user) == 1;
            }
            catch (Exception)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema("El contenido del campo telefono no es soportado por el sistema.");
            }
        }

        public static bool existeCUITExceptuandoA(string cuit, string user)
        {
            try
            {
                return ejecutarProcedureWithReturnValue("existe_cuit_exceptuando_a", cuit, user) == 1;
            }
            catch (Exception)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema("CUIT demasiado largo.");
            }
        }

        public static void editarEmpresa(Empresa empresa)
        {
            AsistenteUsuario.editarDireccion(empresa.direccion);
            Int64 nroTel;
            try
            {
                nroTel = Convert.ToInt64(empresa.telefono);
            }
            catch (FormatException)
            {
                nroTel = 0;
            }
            
            try
            {
                ejecutarProcedure("editar_empresa", empresa.user, empresa.razon, empresa.mail, nroTel,empresa.ciudad,empresa.cuit,empresa.nombreDeContacto,empresa.fechaCreacion);
            }
            catch (Exception)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema();
            }
        }

        public static Empresa newEmpresa(string username)
        {
            DataRow susDatos = getDataEmpresa(username);
            return new Empresa(susDatos);
        }

        public static DataRow getDataEmpresa(string empresa)
        {
            return traerDataTable("get_data_empresa", empresa).Rows[0];
        }
        public static string listarData(Empresa empresa)
        {
            return "Razón: " + empresa.razon + "\n" +
                "Usuario :" + empresa.user + "\n" +
                "Mail: " + empresa.mail + "\n" +
                "Telefono: " + empresa.telefono + "\n" +
                "Dirección: \n" + empresa.direccion.listar() + "\n" +
                "Ciudad: " + empresa.ciudad + "\n" +
                "CUIT: " + empresa.cuit + "\n" +
                "Contacto: " + empresa.nombreDeContacto + "\n" +
                "Fecha de creación: " + empresa.fechaCreacion + "\n";
        }
    }
}
