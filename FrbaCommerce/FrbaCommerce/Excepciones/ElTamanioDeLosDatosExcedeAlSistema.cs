using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{

    public class ElTamanioDeLosDatosExcedeAlSistema : Exception
    {
        public ElTamanioDeLosDatosExcedeAlSistema()
        {
        }

        public ElTamanioDeLosDatosExcedeAlSistema(string message)
            : base(message)
        {
        }

        public ElTamanioDeLosDatosExcedeAlSistema(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
