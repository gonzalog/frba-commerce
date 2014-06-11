using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public class HayCamposEnBlanco : Exception
    {
        public TextBox boxConflictivo;
        
        public HayCamposEnBlanco()
        {
        }

        public HayCamposEnBlanco(string message)
            : base(message)
        {
        }

        public HayCamposEnBlanco(TextBox box)
            : base()
        {
            boxConflictivo = box;
        }
        public string mensajeDefault() 
        {
            return "La casilla " + boxConflictivo.Name + " no puede quedar vacía";
        }

        public HayCamposEnBlanco(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
