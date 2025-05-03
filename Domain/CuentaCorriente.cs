using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto { get; set; }
        public decimal Comision { get; set; }

        public override TipoCuenta Tipo => TipoCuenta.CuentaCorriente;

        public CuentaCorriente(string numero, decimal saldo, string[] titulares, decimal limiteDescubierto, decimal comision)
            : base(numero, saldo, titulares)
        {
            LimiteDeDescubierto = limiteDescubierto;
            Comision = comision;
        }

        public override void Depositar(decimal monto)
        {
            ValidarEstadoActivo();  
            ValidarMonto(monto); 

            Saldo += monto - (monto * Comision);
        }

        public override void Retirar(decimal monto)
        {
            ValidarEstadoActivo();   
            ValidarMonto(monto); 

          
            if (Saldo - monto < -LimiteDeDescubierto)
            {
                throw new SaldoInsuficiente("Saldo insuficiente o límite de descubierto excedido.");
            }

            
            Saldo -= monto;

           
            if (Saldo < 0)
            {
                SuspenderCuenta();  // Suspender la cuenta
            }
        }
    }

}


