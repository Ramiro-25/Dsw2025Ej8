namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }
    public decimal TasaDeInteres { get; protected set; }

    protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Titulares = titulares;
        Estado = Estado.Activa;
    }

    public virtual void SetTasaDeInteres(decimal tasa)
    {
        TasaDeInteres = tasa;
    }

    public abstract TipoCuenta Tipo { get; }

    
    protected void SuspenderCuenta()
    {
        Estado = Estado.Suspendida;
    }

    
    public class MontoNoValido : Exception
    {
        public MontoNoValido(string mensaje) : base(mensaje) { }
    }

    
    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente(string mensaje) : base(mensaje) { }
    }

   
    protected void ValidarMonto(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido("El monto debe ser mayor que cero.");
        }
    }

   
    protected void ValidarEstadoActivo()
    {
        if (Estado != Estado.Activa)
        {
            throw new Exception("La cuenta no está activa.");
        }
    }

    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
}

