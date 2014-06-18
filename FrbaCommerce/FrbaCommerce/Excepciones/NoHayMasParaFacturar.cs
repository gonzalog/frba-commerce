using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class NoHayMasParaFacturar : Exception
    {
        public NoHayMasParaFacturar()
        {
        }

        public NoHayMasParaFacturar(string message)
            : base(message)
        {
        }

        public NoHayMasParaFacturar(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
