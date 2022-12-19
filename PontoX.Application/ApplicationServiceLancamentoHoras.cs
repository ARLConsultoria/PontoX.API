using AutoMapper;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.LancamentoHoras;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;

namespace PontoX.Application
{
    public class ApplicationServiceLancamentoHoras : IApplicationServiceLancamentoHoras
    {
        private readonly IServiceLancamentoHoras _service;
        private readonly IServiceUsuario _serviceUsuario;
        public ApplicationServiceLancamentoHoras(IServiceLancamentoHoras service, IServiceUsuario serviceUsuario)
        {
            _service = service;
            _serviceUsuario = serviceUsuario;
        }

        public async Task<bool> CadastrarLancamentoHoras(LancamentoHorasRequest request)
        {
            if (request.UsuarioId > 0)
            {
                var consulta = await _serviceUsuario.Consultar(request.UsuarioId);
                if (consulta == null)
                {
                    return false;
                }
                else
                {
                    return await _service.Adicionar(new LancamentoHoras()
                    {
                        HoraInicio = request.HoraInicio,
                        HoraFim = request.HoraFim,
                        DataCriacao = request.DataCriacao,
                        DataModificacao = request.DataModificacao,
                        Aprovacao = request.Aprovacao,
                        MensagemAprovacao = request.MensagemAprovacao,
                        UsuarioId = request.UsuarioId
                    });
                }
            }
            else
                return false;
        }

        public async Task<bool> AtualizarLancamentoHoras(LancamentoHorasRequest request)
        {
            if (request.UsuarioId > 0)
            {
                var consulta = await _serviceUsuario.Consultar(request.UsuarioId);

                if (consulta == null)
                {
                    return false;
                }
                else
                {
                    var verification = await _service.Consultar(request.Id);

                    if (verification == null)
                    {
                        return false;
                    }
                    else
                    {
                        verification.Aprovacao = request.Aprovacao;
                        verification.MensagemAprovacao = request.MensagemAprovacao;
                        verification.HoraInicio = request.HoraInicio;
                        verification.HoraFim = request.HoraFim;
                        verification.DataModificacao = DateTime.Now;
                        return await _service.Atualizar(verification);
                    }
                }
            }
            else
                return false;
        }

        public async Task<List<LancamentoHorasResponse>> ListarLancamentoHoras()
        {
            List<LancamentoHorasResponse> lancamentoHorasResponse = new List<LancamentoHorasResponse>();
            var LancamentosHora = await _service.Consultar();

            foreach (var item in LancamentosHora)
            {
                var usuario = await _serviceUsuario.Consultar(item.UsuarioId);

                var lancamento = new LancamentoHorasResponse()
                {
                    HoraInicio = item.HoraInicio,
                    HoraFim = item.HoraFim,
                    DataCriacao = item.DataCriacao,
                    DataModificacao = item.DataModificacao,
                    Aprovacao = item.Aprovacao,
                    MensagemAprovacao = item.MensagemAprovacao,
                    Usuario = new UsuarioResponse()
                    {
                        CPF = usuario.CPF,
                        Ativo = usuario.Ativo, 
                        Nome = usuario.Nome, 
                        Email = usuario.Email,  
                    }
                };
                lancamentoHorasResponse.Add(lancamento);    
            }
            return lancamentoHorasResponse;
        }
    }
}
