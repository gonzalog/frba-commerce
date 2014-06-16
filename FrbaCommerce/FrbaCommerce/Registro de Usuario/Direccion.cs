using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Registro_de_Usuario
{
    public class Direccion
    {
        public int id;
        public string calle;
        public long numero;
        public long piso;
        public string depto;
        public string localidad;
        public string codPostal;

        public Direccion(DataRow filaDireccion) 
        {
            id = Convert.ToInt32(filaDireccion["id"].ToString());
            calle = filaDireccion["calle"].ToString();
            numero = Convert.ToInt64(filaDireccion["numero"].ToString());
            piso = Convert.ToInt64(filaDireccion["piso"].ToString());
            depto = filaDireccion["depto"].ToString();
            localidad = filaDireccion["localidad"].ToString();
            codPostal = filaDireccion["cod_post"].ToString();
        }

        public string listar()
        {
            return calle + " " + numero + " " + piso + " " + depto + "\nLocalidad: " + localidad + "\nCódigo postal: " + codPostal;
        }
    }
}
