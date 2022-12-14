using Microsoft.EntityFrameworkCore;
using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using PontoX.Infrastructure.Data.Repositories;

namespace PontoX.Infrastucture.Infrastructure.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IRepositoryPerfil
    {
        private readonly PontoXContext _context;

        public PerfilRepository(PontoXContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Perfil> ConsultarPorPerfilPaiId(long perfilPaiId)
        {
            return await _context.Set<Perfil>().Where(x => x.Id == perfilPaiId).FirstOrDefaultAsync();
        }

        public async Task<List<Perfil>> ConsultarPerfilTemFilho(long id)
        {
            return await _context.Set<Perfil>().Where(x => x.PerfilPaiId == id).ToListAsync();
        }
    }
}