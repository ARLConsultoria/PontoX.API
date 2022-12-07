using System;
using System.Collections.Generic;

namespace PontoX.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> Consultar();
        Task<T> Consultar(int id);
        Task<bool> Adicionar(T model);
        Task<bool> Atualizar(T model);
        Task<bool> Remover(int id);
    }
}
