using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Registro_de_Usuario;
using System.Windows.Forms;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Abm_Cliente
{
    public class Cliente : Vendedor
    {
        public string user;
        public string nombre;
        public string apellido;
        public string tipoDoc;
        public string nroDoc;
        public string mail;
        public string telefono;
        public DateTime fechaNac;
        public Direccion direccion;

        public Cliente(DataRow filaCliente)
        {
            user = filaCliente["Usuario"].ToString();
            nombre = filaCliente["Nombre"].ToString();
            apellido = filaCliente["Apellido"].ToString();
            tipoDoc = filaCliente["doc_tipo"].ToString();
            nroDoc = filaCliente["doc_numero"].ToString();
            mail = filaCliente["mail"].ToString();
            telefono = filaCliente["telefono"].ToString();
            fechaNac = Convert.ToDateTime(filaCliente["fecha_nacimiento"]);

            DataRow dataDireccion = AsistenteUsuario.getDataDireccion(filaCliente["direccion"].ToString());
            direccion = new Direccion(dataDireccion);
        }

        public void perdurar() 
        {
            string[] atributos = new string[6] {nombre,apellido,tipoDoc,nroDoc,mail,telefono};
            foreach (string atributo in atributos)
                if(atributo=="")
                    throw new HayCamposEnBlanco();
            long docNumerico;
            try
            {
                docNumerico = Convert.ToInt64(nroDoc);
            }
            catch (FormatException)
            {
                throw new HayCamposEnBlanco();
            }
            catch (OverflowException)
            {
                throw new ElTamanioDeLosDatosExcedeAlSistema();
            }
            if (AsistenteCliente.existeTipoYNumeroDocExceptuandoA(tipoDoc,docNumerico,user)) throw new DocumentoRepetido();
            if (AsistenteCliente.existeTelefonoClienteExceptuandoA(telefono, user)) throw new TelefonoYaRegistrado();
            AsistenteCliente.editarCliente(this);
        }
        public void mostrarDatos()
        {
            MessageBox.Show("Cliente vendedor:\n" + AsistenteCliente.listarData(this));
        }
    }
}

