using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    using System;

    public class DocumentoRepetido : Exception
    {
        public DocumentoRepetido()
        {
        }

        public DocumentoRepetido(string message)
            : base(message)
        {
        }

        public DocumentoRepetido(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
