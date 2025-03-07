using Microsoft.AspNetCore.Mvc;
using Necli.Services;
using Necli.Entities;

namespace Necli.Controllers
{
    [Route("api/transacciones")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionService _transaccionService;
        private readonly RegistroService _registroService;

        public TransaccionController()
        {
            _registroService = new RegistroService();
            _transaccionService = new TransaccionService(_registroService.ConsultarTodos());
        }

        [HttpPost]
        public IActionResult RealizarTransaccion([FromBody] Transaccion transaccion)
        {
            try
            {
                var resultado = _transaccionService.RealizarTransaccion(transaccion.Origen, transaccion.Destino, transaccion.Monto, transaccion.Tipo);
                return Created("", resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
