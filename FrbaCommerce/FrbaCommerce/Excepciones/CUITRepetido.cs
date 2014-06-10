using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class CUITRepetido : Exception
    {
        public CUITRepetido()
        {
        }

        public CUITRepetido(string message)
            : base(message)
        {
        }

        public CUITRepetido(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
