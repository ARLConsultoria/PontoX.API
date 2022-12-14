using PontoX.Application.Models.Perfil;
using PontoX.Application.Models.Usuario;

namespace PontoX.Application.Interfaces
{
    public interface IApplicationServicePerfil
    {
        Task<bool> CadastrarPerfil(PerfilRequest cliente);
        Task<bool> ExcluirPerfil(long idCliente);
        Task<bool> AtualizarPerfil(PerfilRequest cliente);
        Task<List<PerfilResponse>> ListarPerfis();
    }
}
