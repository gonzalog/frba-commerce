using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Excepciones;
using FrbaCommerce.Asistentes;

namespace FrbaCommerce.Abm_Visibilidad
{
    public class Visibilidad
    {
        public string cod;
        public string descripcion;
        public string porcentaje;
        public string precio;

        public Visibilidad(DataRow filaVisibilidad)
        {
            cod = filaVisibilidad["codigo"].ToString();
            descripcion = filaVisibilidad["descripcion"].ToString();
            porcentaje = filaVisibilidad["porcentaje"].ToString();
            precio = filaVisibilidad["precio_por_pub"].ToString();
        }

        public void perdurar()
        {
            string[] atributos = new string[3] { descripcion,porcentaje,precio};
            foreach (string atributo in atributos)
                if (atributo == "") throw new HayCamposEnBlanco();

            AsistenteVisibilidad.editarVisibilidad(this);
        }

        public int duracion()
        {
            return Convert.ToInt32(Convert.ToDouble(precio)) + 10;
        }
    }
}
