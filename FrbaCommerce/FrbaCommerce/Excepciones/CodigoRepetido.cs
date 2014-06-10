using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class CodigoRepetido : Exception
    {
        public CodigoRepetido()
        {
        }

        public CodigoRepetido(string message)
            : base(message)
        {
        }

        public CodigoRepetido(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
