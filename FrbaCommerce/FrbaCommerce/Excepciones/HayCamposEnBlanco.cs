using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class HayCamposEnBlanco : Exception
    {
        public HayCamposEnBlanco()
        {
        }

        public HayCamposEnBlanco(string message)
            : base(message)
        {
        }

        public HayCamposEnBlanco(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
