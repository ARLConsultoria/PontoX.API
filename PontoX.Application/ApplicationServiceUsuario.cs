using AutoMapper;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;

namespace PontoX.Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _service;
        public ApplicationServiceUsuario(IServiceUsuario service)
        {
            _service = service;
        }

        public async Task<bool> AtualizarUsuario(UsuarioRequest request)
        {
            return await _service.Atualizar(new Usuario()
            {
                Ativo = request.Ativo,
                CPF = request.CPF,
                Email = request.Email,
                Nome = request.Nome,
                Senha = request.Senha,
                Id = request.Id
            });
        }

        public async Task<bool> CadastrarUsuario(UsuarioRequest request)
        {
            return await _service.Adicionar(new Usuario()
            {
                Ativo = request.Ativo,
                CPF = request.CPF,
                Email = request.Email,
                Nome = request.Nome,
                Senha = request.Senha,
            });
        }

        public async Task<bool> DesativarUsuario(int idCliente)
        {
            var usuario = await _service.Consultar(idCliente);
            usuario.Ativo = false;
            return await _service.Atualizar(usuario);
        }

        public async Task<List<UsuarioResponse>> ListarUsuarios()
        {
            List<UsuarioResponse> usuarioResponses = new List<UsuarioResponse>();
            var usuarios = await _service.Consultar();
            //todo = criar autoMapper
            foreach (var item in usuarios)
                usuarioResponses.Add(new UsuarioResponse()
                {
                    Ativo = item.Ativo,
                    CPF = item.CPF,
                    Email = item.Email,
                    Nome = item.Nome,
                    Senha = item.Senha,
                });

            return usuarioResponses;
        }
    }
}
