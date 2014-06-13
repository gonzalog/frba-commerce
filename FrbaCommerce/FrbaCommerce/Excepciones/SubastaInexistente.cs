using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class SubastaInexistente : Exception
    {
        public SubastaInexistente()
        {
        }

        public SubastaInexistente(string message)
            : base(message)
        {
        }

        public SubastaInexistente(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
