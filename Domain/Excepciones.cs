using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class MontoNoValido : Exception
    {
        public MontoNoValido(string mensaje) : base(mensaje) { }
    }
    
        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva()
                : base("La cuenta no está activa para realizar operaciones.") { }

            public CuentaNoActiva(string mensaje)
                : base(mensaje) { }

            public CuentaNoActiva(string mensaje, Exception inner)
                : base(mensaje, inner) { }
        }
    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente(string mensaje) : base(mensaje) { }
    }
   
}


