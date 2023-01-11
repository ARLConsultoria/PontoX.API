using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;
using ServiceBlackDomain.Services;

namespace PontoX.Domain.Service.ServiceUsuario
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;

        public ServiceUsuario(IRepositoryUsuario repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> BuscarLogin(string email, string senha) => await _repository.BuscarLogin(email, senha); 
    }
}
