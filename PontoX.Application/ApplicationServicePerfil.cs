using AutoMapper;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Perfil;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;
using System.Security;

namespace PontoX.Application
{
    public class ApplicationServicePerfil : IApplicationServicePerfil
    {
        private readonly IServicePerfil _service;
        private readonly IMapper _mapper;   
        public ApplicationServicePerfil(IServicePerfil service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarPerfil(PerfilRequest request)
        {
            return await _service.Atualizar(_mapper.Map<Perfil>(request));
        }

        public async Task<bool> CadastrarPerfil(PerfilRequest request)
        {
            if (request.PerfilPaiId == null || request.PerfilPaiId == 0)
            {
                return await _service.Adicionar(_mapper.Map<Perfil>(request));
            }
            else
            {
                var consulta = _service.ConsultarPorPerfilPaiId(request.PerfilPaiId);
                if (consulta != null)
                {
                    return await _service.Adicionar(_mapper.Map<Perfil>(request));
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<bool> ExcluirPerfil(long idCliente)
        {
            var perfilCliente = await _service.Consultar(idCliente);
            if (perfilCliente == null)
            {
                return false;
            }
            else
            {
                var verification = await _service.ConsultarPerfilTemFilho(perfilCliente.Id);
                if (verification.Count == 0)
                {
                    _service.Remover(perfilCliente.Id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<PerfilResponse>> ListarPerfis()
        {
            List<PerfilResponse> perfilResponse = new List<PerfilResponse>();
            var perfis = await _service.Consultar();
            foreach (var item in perfis)
            {
                var perfilPai = new Perfil();
                perfilPai = await _service.ConsultarPorPerfilPaiId(item.PerfilPaiId);

                var perfil = _mapper.Map<PerfilResponse>(perfilPai);

                if (perfilPai != null)
                {
                    perfil.PerfilPai = _mapper.Map<PerfilResponse>(perfilPai);
                }
                perfilResponse.Add(perfil);
            }
            return perfilResponse;
        }
    }
}
