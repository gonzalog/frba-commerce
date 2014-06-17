using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Calificar_Vendedor;

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
            try
            {
                return ejecutarProcedureWithReturnValue("existe_telefono_cliente", Convert.ToInt64(telefono)) == 1;
            }
            catch (OverflowException)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema();
            }
        }

        public static bool existeTelefonoClienteExceptuandoA(string telefono,string user)
        {
            try
            {
                return ejecutarProcedureWithReturnValue("existe_telefono_cliente_exceptuando_a", Convert.ToInt64(telefono), user) == 1;
            }
            catch (Exception)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema("El contenido del campo telefono no es soportado por el sistema.");
            }
        }

        public static void chequearTipoYNroDocNoRepetido(string tipo, string numero, List<string> errores) 
        {
            try
            {
                if (existeTipoYNumeroDoc(tipo, Convert.ToInt64(numero)))
                {
                    errores.Add("Ya existe un cliente con tal tipo y número de documento.\n Se le recuerda que cada cliente puede estar registrado una única vez.");
                }
            }
            catch (OverflowException)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema("El contenido del campo número de documento no es soportado por el sistema.");
            }
        }

        public static bool existeTipoYNumeroDoc(string tipo, Int64 numero)
        {
            return ejecutarProcedureWithReturnValue("existe_tipo_y_numero_doc",tipo,numero) == 1;
        }

        public static bool existeTipoYNumeroDocExceptuandoA(string tipo, Int64 numero, string user)
        {
            return ejecutarProcedureWithReturnValue("existe_tipo_y_numero_doc_exceptuando_a", tipo, numero, user) == 1;
        }

        public static DataTable getTableBuscando(string nombre, string apellido, string tipo, string numero, string email)
        {
            return traerDataTable("get_clientes_buscando",nombre,apellido,tipo,numero,email);
        }

        public static DataRow getDataCliente(string cliente)
        {
            return traerDataTable("get_data_cliente",cliente).Rows[0];
        }

        public static Cliente newCliente(string username)
        {
            DataRow susDatos = getDataCliente(username);
            return new Cliente(susDatos);
        }

        public static void editarCliente(Cliente cliente)
        {
            AsistenteUsuario.editarDireccion(cliente.direccion);
            Int64 nroTel;
            try
            {
                nroTel = Convert.ToInt64(cliente.telefono);
            }
            catch (FormatException)
            {
                nroTel = 0;
            }
            Int64 nroDoc;
            try
            {
                nroDoc = Convert.ToInt64(cliente.nroDoc);
            }
            catch (FormatException)
            {
                nroDoc = 0;
            }
            try
            {
                ejecutarProcedure("editar_cliente", cliente.user, cliente.nombre, cliente.apellido, cliente.tipoDoc, nroDoc,
                    cliente.mail, nroTel, cliente.fechaNac);
            }
            catch (Exception)
            { 
                throw new ElTamanioDeLosDatosExcedeAlSistema();
            }
        }

        public static string listarData(Cliente cliente)
        {
            return "Usuario: " + cliente.user + "\n" +
                "Nombre: " + cliente.nombre + "\n" +
                "Apellido: " + cliente.apellido + "\n" +
                "Documento personal: " + cliente.tipoDoc + " " + cliente.nroDoc + "\n" +
                "Fecha de nacimiento: " + cliente.fechaNac + "\n" +
                "E-mail: " + cliente.mail + "\n" +
                "Teléfono: " + cliente.telefono + "\n" +
                "Dirección: \n" + cliente.direccion.listar();
        }

        public static List<Adquisicion> packComprasACalificar(string cliente,int inicial)
        {
            DataTable tabla = traerDataTable("get_pack_compras_a_calificar", cliente,inicial);
            List<Adquisicion> lista = new List<Adquisicion>();
            foreach (DataRow fila in tabla.Rows)
            {
                Adquisicion compra = new Adquisicion
                    (fila["TIPO"].ToString(), Convert.ToInt32(fila["CODIGO"].ToString()));
                lista.Add(compra);
            }
            return lista;
        }
    }
}
