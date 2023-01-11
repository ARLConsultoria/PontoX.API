using Microsoft.EntityFrameworkCore;
using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using PontoX.Infrastructure.Data.Repositories;

namespace PontoX.Infrastucture.Infrastructure.Data.Repositories
{
    public class LancamentoHorasRepository : BaseRepository<LancamentoHoras>, IRepositoryLancamentoHoras
    {
        private readonly PontoXContext _context;

        public LancamentoHorasRepository(PontoXContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LancamentoHoras>> ConsultarLancamentoHorasCompleto()
        {
           return await _context.Set<LancamentoHoras>().Include(x => x.Usuario).ToListAsync();
        }
    }
}