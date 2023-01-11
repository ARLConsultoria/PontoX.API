using PontoX.Domain.Entities;

namespace PontoX.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Task<Usuario> BuscarLogin(string email, string senha);
    }
 
}
