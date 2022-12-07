﻿using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using PontoX.Infrastructure.Data.Repositories;

namespace PontoX.Infrastucture.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IRepositoryUsuario
    {
        private readonly PontoXContext _context;

        public UsuarioRepository(PontoXContext context) : base(context)
        {
            _context = context;
        }
    }
}