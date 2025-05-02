namespace Dsw2025Ej8.Domain;
{
    public abstract class CuentaBancaria
{
    public TipoCuenta Tipo { get; }
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        ValidarMonto(saldo);
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;s
        Estado = Estado.Activa;
        Titulares = titulares;
    }

}