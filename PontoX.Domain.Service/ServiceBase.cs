using PontoX.Domain.Core.Interfaces.Repositories;
using ServiceBlackDomain.Core.Interfaces.Services;

namespace ServiceBlackDomain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(T model) => await _repository.Adicionar(model);

        public async Task<bool> Remover(long id) => await _repository.Remover(id);

        public async Task<IEnumerable<T>> Consultar() => await _repository.Consultar();

        public async Task<T> Consultar(long id) => await _repository.Consultar(id);

        public async Task<bool> Atualizar(T model) => await _repository.Atualizar(model);
    }
}
