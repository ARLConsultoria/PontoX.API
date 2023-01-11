using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;
using ServiceBlackDomain.Services;

namespace PontoX.Domain.Service.ServiceLancamentoHoras
{
    public class ServiceLancamentoHoras : ServiceBase<LancamentoHoras>, IServiceLancamentoHoras
    {
        private readonly IRepositoryLancamentoHoras _repository;

        public ServiceLancamentoHoras(IRepositoryLancamentoHoras repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<List<LancamentoHoras>> BuscarLancamentoHorasCompleto() => await _repository.ConsultarLancamentoHorasCompleto(); 
    }
}
