using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class NombreInvalido : Exception
    {
        public NombreInvalido()
        {
        }

        public NombreInvalido(string message)
            : base(message)
        {
        }

        public NombreInvalido(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
