using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Asistentes;
using System.Data;

namespace FrbaCommerce.Calificar_Vendedor
{
    public class Adquisicion
    {
        public string tipo;
        public int codigo;
        public Cliente cliente;
        public Publicacion publicacion;
        public string cantidad;
        public Adquisicion(string tipo, int cod)
        {
            DataRow fila = AsistenteCompra.getDataCompra(cod);
            this.tipo = tipo;
            this.codigo = cod;
            this.cliente = new Cliente
                (
                AsistenteCliente.getDataCliente(fila["CLIENTE"].ToString())
                );
            this.publicacion = new Publicacion(Convert.ToInt32(fila["PUBLICACION"].ToString()));
            this.cantidad = fila["cant_comprada"].ToString();
        }

    }
}
