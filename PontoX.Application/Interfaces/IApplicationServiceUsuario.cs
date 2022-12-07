using PontoX.Application.Models.Usuario;

namespace PontoX.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<bool> CadastrarUsuario(UsuarioRequest cliente);
        Task<bool> DesativarUsuario(int idCliente);
        Task<bool> AtualizarUsuario(UsuarioRequest cliente);
        Task<List<UsuarioResponse>> ListarUsuarios();
    }
}
