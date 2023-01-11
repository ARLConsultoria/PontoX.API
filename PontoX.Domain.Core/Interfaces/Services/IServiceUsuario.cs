using PontoX.Domain.Entities;

namespace ServiceBlackDomain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task<Usuario> BuscarLogin(string email, string senha);
    }
}
