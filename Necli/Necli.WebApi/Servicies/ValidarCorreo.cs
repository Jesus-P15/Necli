using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace Necli.WebApi.Servicies
{
    public class ValidarCorreo
    {

        private static readonly string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

     
        public string Email { get; set; }

        public static bool EsCorreoValido(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return false;
            }

            return Regex.IsMatch(Email, pattern);
        }
    }
}
