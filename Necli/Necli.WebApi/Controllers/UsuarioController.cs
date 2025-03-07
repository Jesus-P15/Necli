using Microsoft.AspNetCore.Mvc;
using Necli.Services;
using Necli.WebApi.Entities;
using Necli.WebApi.Servicies;
using System.Collections.Generic;

namespace Necli.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public static List<Usuario> Usuarios = new List<Usuario>
        {
           new Usuario { idUsuario = "U001", NombreU = "Juan", ApellidoU = "Pérez", Contrasena = "12345", Email = new ValidarCorreo { Email = "juan@example.com" }, Numero = "3001234567", Saldo = 50000 },
            new Usuario { idUsuario = "U002", NombreU = "Maria", ApellidoU = "Gomez", Contrasena = "abcde", Email = new ValidarCorreo { Email = "maria@example.com" }, Numero = "3007654321", Saldo = 120000 },
            new Usuario { idUsuario = "U003", NombreU = "Carlos", ApellidoU = "Rodriguez", Contrasena = "qwerty", Email = new ValidarCorreo { Email = "carlos@example.com" }, Numero = "3156789012", Saldo = 75000 },
            new Usuario { idUsuario = "U004", NombreU = "Ana", ApellidoU = "Martinez", Contrasena = "secure123", Email = new ValidarCorreo { Email = "ana@example.com" }, Numero = "3123456789", Saldo = 200000 },
            new Usuario { idUsuario = "U005", NombreU = "David", ApellidoU = "Fernandez", Contrasena = "pass123", Email = new ValidarCorreo { Email = "david@example.com" }, Numero = "3204567890", Saldo = 60000 },
            new Usuario { idUsuario = "U006", NombreU = "Laura", ApellidoU = "Hernandez", Contrasena = "lauraPass", Email = new ValidarCorreo { Email = "laura@example.com" }, Numero = "3109876543", Saldo = 85000 },
            new Usuario { idUsuario = "U007", NombreU = "Andres", ApellidoU = "Ruiz", Contrasena = "ruiz123", Email = new ValidarCorreo { Email = "andres@example.com" }, Numero = "3165432109", Saldo = 45000 },
            new Usuario { idUsuario = "U008", NombreU = "Sofia", ApellidoU = "Diaz", Contrasena = "sofia321", Email = new ValidarCorreo { Email = "sofia@example.com" }, Numero = "3045678901", Saldo = 300000 },
            new Usuario { idUsuario = "U009", NombreU = "Jorge", ApellidoU = "Mendoza", Contrasena = "mendozapass", Email = new ValidarCorreo { Email = "jorge@example.com" }, Numero = "3112345678", Saldo = 150000 },
            new Usuario { idUsuario = "U010", NombreU = "Camila", ApellidoU = "Lopez", Contrasena = "lopez456", Email = new ValidarCorreo { Email = "camila@example.com" }, Numero = "3198765432", Saldo = 100000 }
         };


        [HttpPost]
        public ActionResult<string> CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest("Revise la información de la cuenta del usuario.");
            }

            if (Usuarios.Any(l => l.idUsuario == usuario.idUsuario))
            {
                return Conflict("Ya existe una cuenta con este ID.");
            }

            Usuarios.Add(usuario);
            return Ok("La cuenta se ha creado de forma correcta.");
        }

        [HttpGet("{IdUsuario}")]
        public ActionResult<Usuario> ConsultarLibro(string IdUsuario)
        {
            var libroEncontrado = Usuarios.FirstOrDefault(l => l.idUsuario == IdUsuario);

            if (libroEncontrado is null)
            {
                return NotFound($"No se encontró un usuario con el Id: {IdUsuario}");
            }

            return Ok(libroEncontrado);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ConsultarLibros()
        {
            if (Usuarios is null)
            {
                BadRequest();
            }

            return Ok(Usuarios);
        }

        [HttpPut("{IdUsuario}")]
        public ActionResult<string> ActualizarUsuario(string IdUsuario, [FromBody] Usuario usuarioActualizado)
        {
            var UsuarioExistente = Usuarios.FirstOrDefault(l => l.idUsuario == IdUsuario);

            if (UsuarioExistente is null)
            {
                return NotFound($"No se encontró un usuario con el Id: {IdUsuario}");
            }
            UsuarioExistente.idUsuario = usuarioActualizado.idUsuario;
            UsuarioExistente.NombreU = usuarioActualizado.NombreU;
            UsuarioExistente.ApellidoU = usuarioActualizado.ApellidoU;
            UsuarioExistente.Contrasena = usuarioActualizado.Contrasena;
            UsuarioExistente.Email = usuarioActualizado.Email;
            UsuarioExistente.Numero = usuarioActualizado.Numero;
            UsuarioExistente.Saldo = usuarioActualizado.Saldo;

            return Ok("La cuenta del usuario ha sido actualizada correctamente.");
        }

        [HttpDelete("{IdUsuario}")]
        public ActionResult<string> EliminarLibro(string IdUsuario)
        {
            var UsuarioExistente = Usuarios.FirstOrDefault(l => l.idUsuario == IdUsuario);

            if (UsuarioExistente is null)
            {
                return NotFound($"No se encontró un usuario con el Id: {IdUsuario}");
            }

            Usuarios.Remove(UsuarioExistente);
            return Ok("La cuenta del usuario ha sido eliminado correctamente.");
        }
    }
}
