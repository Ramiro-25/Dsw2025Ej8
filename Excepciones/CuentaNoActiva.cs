using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Excepciones
{
    public class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(string estado) : base($"no se puede operar con la cuenta {estado}.")
        {

        }
    }
}
