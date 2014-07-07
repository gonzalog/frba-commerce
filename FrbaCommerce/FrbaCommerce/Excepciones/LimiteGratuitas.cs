using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class LimiteGratuitas : Exception
    {
        public LimiteGratuitas()
        {
        }

        public LimiteGratuitas(string message)
            : base(message)
        {
        }

        public LimiteGratuitas(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}