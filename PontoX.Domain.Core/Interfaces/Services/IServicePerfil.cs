using PontoX.Domain.Entities;

namespace ServiceBlackDomain.Core.Interfaces.Services
{
    public interface IServicePerfil : IServiceBase<Perfil>
    {
        Task<Perfil> ConsultarPorPerfilPaiId(long perfilPaiId);
        Task<List<Perfil>> ConsultarPerfilTemFilho(long id);
    }
}
