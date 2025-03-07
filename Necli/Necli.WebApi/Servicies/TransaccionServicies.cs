using Necli.Entities;
using Necli.WebApi.Entities;
using Necli.WebApi.Enums;

namespace Necli.Services
{
    public class TransaccionService
    {
        private readonly List<Transaccion> _transacciones = new List<Transaccion>();
        private readonly List<Usuario> usuarios;

        public TransaccionService(List<Usuario> cuentas)
        {
            usuarios = cuentas;
        }

        public Transaccion RealizarTransaccion(string origen, string destino, decimal monto, TipoTransaccion tipo)
        {
            var cuentaOrigen = usuarios.FirstOrDefault(c => c.idUsuario == origen);
            var cuentaDestino = usuarios.FirstOrDefault(c => c.idUsuario == destino);

            if (cuentaOrigen == null || cuentaDestino == null)
                throw new Exception("Una de las cuentas no existe.");

            if (monto < 1000 || monto > 5000000)
                throw new Exception("El monto debe estar entre $1.000 y $5.000.000 COP.");

            if (tipo == TipoTransaccion.Enviado && cuentaOrigen.Saldo < monto)
                throw new Exception("Saldo insuficiente.");

            var transaccion = new Transaccion
            {
                Numero = Guid.NewGuid().ToString(),
                Fecha = DateTime.Now,
                Origen = origen,
                Destino = destino,
                Monto = monto,
                Tipo = tipo
            };

            if (tipo == TipoTransaccion.Enviado)
            {
                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;
            }

            _transacciones.Add(transaccion);
            return transaccion;
        }

        public List<Transaccion> ObtenerTransacciones()
        {
            return _transacciones;
        }
    }
}
