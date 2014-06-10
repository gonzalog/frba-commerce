using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class FallaDelMotor : Exception
    {
        public FallaDelMotor()
        {
        }

        public FallaDelMotor(string message)
            : base(message)
        {
        }

        public FallaDelMotor(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
