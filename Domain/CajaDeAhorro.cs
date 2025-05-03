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
            try
            {
                ValidarEstadoActivo();  
                ValidarMonto(monto);   

                Saldo += monto;
            }
            catch (MontoNoValido ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        public override void Retirar(decimal monto)
        {
            try
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
            catch (MontoNoValido ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (SaldoInsuficiente ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
}

