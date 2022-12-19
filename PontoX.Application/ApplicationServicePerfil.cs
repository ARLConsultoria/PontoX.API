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
        public ApplicationServicePerfil(IServicePerfil service)
        {
            _service = service;
        }

        public async Task<bool> AtualizarPerfil(PerfilRequest request)
        {
            return await _service.Atualizar(new Perfil()
            {
                PerfilPaiId = request.PerfilPaiId,
                Nome = request.Nome,
                DataCriacao = request.DataCriacao,
                DataModificacao = request.DataModificacao,
                Id = request.Id
            });
        }

        public async Task<bool> CadastrarPerfil(PerfilRequest request)
        {
            if (request.PerfilPaiId == null || request.PerfilPaiId == 0)
            {
                return await _service.Adicionar(new Perfil()
                {
                    PerfilPaiId = request.PerfilPaiId,
                    Nome = request.Nome,
                    DataCriacao = request.DataCriacao,
                    DataModificacao = request.DataModificacao
                });
            }
            else
            {
                var consulta = _service.ConsultarPorPerfilPaiId(request.PerfilPaiId);
                if (consulta != null)
                {
                    return await _service.Adicionar(new Perfil()
                    {
                        PerfilPaiId = request.PerfilPaiId,
                        Nome = request.Nome,
                        DataCriacao = request.DataCriacao,
                        DataModificacao = request.DataModificacao
                    });
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

        public async Task<List<PerfilResponse>> ListarPerfis()
        {
            List<PerfilResponse> perfilResponse = new List<PerfilResponse>();
            var perfis = await _service.Consultar();
            foreach (var item in perfis)
            {
                var perfilPai = new Perfil();
                perfilPai = await _service.ConsultarPorPerfilPaiId(item.PerfilPaiId);

                var perfil = new PerfilResponse()
                {
                    Nome = item.Nome,
                    DataCriacao = item.DataCriacao,
                    DataModificacao = item.DataModificacao,
                };

                if (perfilPai != null)
                {
                    perfil.PerfilPai = new PerfilResponse()
                    {
                        Nome = perfilPai.Nome,
                        DataCriacao = item.DataCriacao,
                    };
                }
                perfilResponse.Add(perfil);
            }
            return perfilResponse;
        }
    }
}
