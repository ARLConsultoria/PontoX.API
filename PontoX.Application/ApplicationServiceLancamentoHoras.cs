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
        private readonly IMapper _mapper;
        public ApplicationServiceLancamentoHoras(IServiceLancamentoHoras service, IServiceUsuario serviceUsuario, IMapper mapper)
        {
            _service = service;
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarLancamentoHoras(LancamentoHorasRequest request)
        {
            if (request.UsuarioId > 0)
            {
                VerificacaoLancamento(request);
                var consulta = await _serviceUsuario.Consultar(request.UsuarioId);
                if (consulta == null)
                {
                    return false;
                }
                else
                {
                    return await _service.Adicionar(_mapper.Map<LancamentoHoras>(request));
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
            var lancamentosHora = await _service.BuscarLancamentoHorasCompleto();
            foreach (var item in lancamentosHora)
            {
                lancamentoHorasResponse.Add(_mapper.Map<LancamentoHorasResponse>(item));
            }
            return lancamentoHorasResponse;
        }

        public async Task<LancamentoHorasRequest> VerificacaoLancamento(LancamentoHorasRequest request)
        {
            if (request.HoraInicio >= 8 && request.HoraFim <= 12)
            {
                request.Aprovacao = true;
                return request;
            } 
            else if (request.HoraInicio >= 13 && request.HoraFim <= 18)
            {
                request.Aprovacao = true;
                return request;
            }
            else
            {
                var mensagemAprovacao = request.MensagemAprovacao;

                if (mensagemAprovacao == null || mensagemAprovacao == "" ||mensagemAprovacao == " ") 
                {
                    request.Aprovacao = false;
                    return request;
                }
                else
                {
                    request.Aprovacao = true;
                    return request;
                }
            }
        }
    }
}
