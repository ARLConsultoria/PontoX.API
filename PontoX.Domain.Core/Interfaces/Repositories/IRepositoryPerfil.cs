using PontoX.Domain.Entities;

namespace PontoX.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryPerfil : IRepositoryBase<Perfil> 
    {
        Task<Perfil> ConsultarPorPerfilPaiId(long perfilPaiId);
        Task<List<Perfil>> ConsultarPerfilTemFilho(long id);
    }
}
