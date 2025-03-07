using System;

namespace Necli.WebApi.Services
{
    public  class GenerarNumTransaccion
    {


        public required string Numero { get; set; }

        private static int contador = 1;

   
        public static string GenerarNumeroTransaccion()
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string aleatorio = new Random().Next(1000, 9999).ToString();
            string numeroTransaccion = $"TX-{fecha}-{contador:D5}-{aleatorio}";

            contador++; // Incrementar contador
            return numeroTransaccion;
        }
    }
}
