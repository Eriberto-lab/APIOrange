using API.Models;

namespace API.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarUsuarioAsync(Usuario usuario);
        Task<bool> UsuarioExisteAsync(string email);
    }
}
