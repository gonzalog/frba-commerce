using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class TipoIncorrecto : Exception
    {
        public TipoIncorrecto()
        {
        }

        public TipoIncorrecto(string message)
            : base(message)
        {
        }

        public TipoIncorrecto(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
