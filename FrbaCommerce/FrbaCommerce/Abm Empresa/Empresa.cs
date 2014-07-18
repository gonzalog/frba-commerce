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

namespace FrbaCommerce.Abm_Empresa
{
    public class Empresa : Vendedor
    {
        public string user;
        public string razon;
        public string mail;
        public string telefono;
        public Direccion direccion;
        public string ciudad;
        public string cuit;
        public string nombreDeContacto; 
        public DateTime fechaCreacion;

        public Empresa(DataRow filaEmpresa)
        {
            user = filaEmpresa["Usuario"].ToString();
            razon = filaEmpresa["razon_social"].ToString();
            mail = filaEmpresa["mail"].ToString();
            telefono = filaEmpresa["telefono"].ToString();
            DataRow dataDireccion = AsistenteUsuario.getDataDireccion(filaEmpresa["direccion"].ToString());
            direccion = new Direccion(dataDireccion);
            ciudad = filaEmpresa["ciudad"].ToString();
            cuit = filaEmpresa["cuit"].ToString();
            nombreDeContacto = filaEmpresa["Nombre_de_contacto"].ToString();
            fechaCreacion = Convert.ToDateTime(filaEmpresa["fecha_creacion"]);    
        }

        public void perdurar()
        {
            string[] atributos = new string[6] { razon, mail, telefono,ciudad,cuit,nombreDeContacto};
            foreach (string atributo in atributos)
                if (atributo == "")
                    throw new HayCamposEnBlanco();
            
            if (AsistenteEmpresa.existeCUITExceptuandoA(cuit, user)) throw new CUITRepetido();
            if (AsistenteEmpresa.existeTelefonoEmpresaExceptuandoA(telefono, user)) throw new TelefonoYaRegistrado();
            AsistenteEmpresa.editarEmpresa(this);
        }
        public void mostrarDatos()
        {
            MessageBox.Show("Empresa vendedora:\n"+AsistenteEmpresa.listarData(this));
        }

        public string getPrimeraParteCUIT()
        {
            return getParteCuit(0);
        }
        public string getSegundaParteCUIT()
        {
            return getParteCuit(1);
        }
        public string getTerceraParteCUIT()
        {
            return getParteCuit(2);
        }

        public string getParteCuit(int parteNumero)
        {
            string[] partes = cuit.Split(new Char[] { '-' });

            return partes[parteNumero];
        }
    }
}
