using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlackDomain.Core.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> Consultar();
        Task<T> Consultar(int id);
        Task<bool> Adicionar(T model);
        Task<bool> Atualizar(T model);
        Task<bool> Remover(int id);
    }
}
