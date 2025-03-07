using Necli.WebApi.Enums;
using Necli.WebApi.Services;

namespace Necli.Entities
{
    public class Transaccion
    {
        public GenerarNumTransaccion Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Monto { get; set; }
        public TipoTransaccion Tipo { get; set; }
    }
}
