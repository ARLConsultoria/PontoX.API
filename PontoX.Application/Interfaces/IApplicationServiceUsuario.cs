using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;

namespace PontoX.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<bool> CadastrarUsuario(UsuarioRequest cliente);
        Task<bool> DesativarUsuario(int idCliente);
        Task<bool> AtualizarUsuario(UsuarioRequest cliente);
        Task<List<UsuarioResponse>> ListarUsuarios();
        Task<Usuario> BuscarPor(string email, string senha);
    }
}
