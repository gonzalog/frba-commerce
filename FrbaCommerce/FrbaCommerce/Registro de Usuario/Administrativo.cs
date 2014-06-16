using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Registro_de_Usuario
{
    class Administrador : Vendedor
    {
        public void mostrarDatos()
        {
            System.Windows.Forms.MessageBox.Show("Esta publicación fue generada por el administrador de FrbaCommerce.");
        }
    }
}
