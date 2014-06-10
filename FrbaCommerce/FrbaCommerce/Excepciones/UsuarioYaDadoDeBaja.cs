﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Excepciones
{
    class BajaYaEfectuada : Exception
    {
        public BajaYaEfectuada()
        {
        }

        public BajaYaEfectuada(string message)
            : base(message)
        {
        }

        public BajaYaEfectuada(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
