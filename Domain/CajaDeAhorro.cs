using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public override TipoCuenta Tipo => TipoCuenta.CajaDeAhorro;

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares)
        {
        }

        public override void Depositar(decimal monto)
        {
            ValidarEstadoActivo();  
            ValidarMonto(monto);  

            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            ValidarEstadoActivo();  
            ValidarMonto(monto); 

            
            if (monto > Saldo)
            {
                throw new SaldoInsuficiente("Fondos insuficientes.");
            }

          
            Saldo -= monto;

            
            if (Saldo < 0)
            {
                SuspenderCuenta(); 
            }
        }

        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }

}
