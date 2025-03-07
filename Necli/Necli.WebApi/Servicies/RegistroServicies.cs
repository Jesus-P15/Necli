using Necli.WebApi.Entities;
using Necli.WebApi.Servicies;

namespace Necli.Services
{
    public class RegistroService
    {

        private List<Usuario> Usuarios = [];

        public void Agregar(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public List<Usuario> ConsultarTodos()
        {

            return Usuarios;

        }
    }
}