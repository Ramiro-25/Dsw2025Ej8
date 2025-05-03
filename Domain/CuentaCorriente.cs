using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares, decimal limiteDescubierto, decimal comision)
    : base(numero, saldo, titulares)
        {
            LimiteDeDescubierto = limiteDescubierto;
            Comision = comision;
        }

        public decimal LimiteDeDescubierto { get; set; }
        public decimal Comision { get; set; }

        public override TipoCuenta Tipo => TipoCuenta.CuentaCorriente;


        public override void Depositar(decimal monto)
        {
            try
            {
                ValidarEstadoActivo(); 
                ValidarMonto(monto);   

                Saldo += monto - (monto * Comision);
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

                if (Saldo - monto < -LimiteDeDescubierto)
                {
                    throw new SaldoInsuficiente("Saldo insuficiente o límite de descubierto excedido.");
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
    }
}



