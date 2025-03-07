using Microsoft.AspNetCore.Mvc;
using Necli.WebApi.Servicies;
using System.Data;

namespace Necli.WebApi.Entities
{
    public class Usuario
    {

        public required string idUsuario { get; set; }
        public required string NombreU { get; set; }
        public required string ApellidoU { get; set; }
        public required string Contrasena { get; set; }

        public ValidarCorreo Email { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }

    }



}
