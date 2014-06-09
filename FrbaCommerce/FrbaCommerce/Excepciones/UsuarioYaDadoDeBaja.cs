using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class UsuarioYaDadoDeBaja : Exception
    {
        public UsuarioYaDadoDeBaja()
        {
        }

        public UsuarioYaDadoDeBaja(string message)
            : base(message)
        {
        }

        public UsuarioYaDadoDeBaja(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
