using Microsoft.EntityFrameworkCore;
using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Infrastucture;

namespace PontoX.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : class
    {
        private readonly PontoXContext _context;

        public BaseRepository(PontoXContext context)
        {
            _context = context;
        }

        public async Task<bool> Adicionar(T model)
        {
            await _context.Set<T>().AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Remover(int id)
        {
            var model = await _context.Set<T>().FindAsync(id);

            if (model == null)
                return false;

            _context.Set<T>().Remove(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> Consultar()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Consultar(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Atualizar(T model)
        {
            _context.Set<T>().Update(model);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}