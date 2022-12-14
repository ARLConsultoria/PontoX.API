using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;
using ServiceBlackDomain.Services;

namespace PontoX.Domain.Service.ServiceUsuario
{
    public class ServicePerfil : ServiceBase<Perfil>, IServicePerfil
    {
        private readonly IRepositoryPerfil _repository;

        public ServicePerfil(IRepositoryPerfil repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Perfil> ConsultarPorPerfilPaiId(long perfilPaiId) => await _repository.ConsultarPorPerfilPaiId(perfilPaiId);
        public async Task<List<Perfil>> ConsultarPerfilTemFilho(long id) => await _repository.ConsultarPerfilTemFilho(id);

    }
}
