using Dsw2025Ej8.Domain;


    internal class Program
    {
        static void Main(string[] args)
        {



            var cuentaAhorro1 = new CajaDeAhorro("CA123", 1000, new string[] { "Juan" });
            var cuentaAhorro2 = new CajaDeAhorro("CA124", 500, new string[] { "Ana" });

            var cuentaCorriente1 = new CuentaCorriente("CC123", 2000, new string[] { "Pedro" }, 500, 0.02m);
            var cuentaCorriente2 = new CuentaCorriente("CC124", 3000, new string[] { "Luis" }, 1000, 0.05m);


            cuentaAhorro1.Depositar(500);
            cuentaAhorro2.Retirar(200);

            cuentaCorriente1.Depositar(1000);
            cuentaCorriente2.Retirar(3500);


            var cuentas = new List<CuentaBancaria>
        {
            cuentaAhorro1,
            cuentaAhorro2,
            cuentaCorriente1,
            cuentaCorriente2
        };


            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.Tipo,
                    Saldo = cuenta.Saldo
                };


                Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }
        }
    }


