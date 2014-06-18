using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Asistentes;
using FrbaCommerce.Excepciones;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public class Tarjeta : FormaDePago
    {
        public string numero;
        public string nombre;
        public string apellido;

        public Tarjeta(SiguienteARendir form)
        {
            numero = form.getNumero();
            nombre = form.getNombre();
            apellido = form.getApellido();
        }

        public override void perdurar(int factura,int numeroDeRenglon)
        {
            try
            {
                AdaptadorBD.ejecutarProcedure("alta_tarjeta", numero, nombre, apellido, factura, numeroDeRenglon);
            }
            catch (FallaDelMotor)
            { 
                //Entra cuando ya fue registrado.
            }
        }

        public override string getNombre()
        {
            return "Tarjeta";
        }
    }
}
